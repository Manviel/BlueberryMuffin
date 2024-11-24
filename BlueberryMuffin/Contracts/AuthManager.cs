using AutoMapper;
using BlueberryMuffin.Configurations;
using BlueberryMuffin.Data;
using BlueberryMuffin.Data.Relation;
using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlueberryMuffin.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(AccountDetails userDetails);
        Task<AuthResponse?> Login(LoginDetails loginDetails);
        Task<string> CreateRefreshToken(ApiUser user);
        Task<AuthResponse?> VerifyRefreshToken(AuthResponse request);
    }

    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateRefreshToken(ApiUser user)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, AppSettings.LoginProviderName, AppSettings.RefreshToken);

            var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, AppSettings.LoginProviderName, AppSettings.RefreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(user, AppSettings.LoginProviderName, AppSettings.RefreshToken, newRefreshToken);

            return newRefreshToken;
        }

        public async Task<AuthResponse?> Login(LoginDetails loginDetails)
        {
            var user = await _userManager.FindByEmailAsync(loginDetails.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDetails.Password);

            if (user == null || isValidUser == false)
            {
                return null;
            }

            var token = await GenerateToken(user);

            return new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                RefreshToken = await CreateRefreshToken(user),
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(AccountDetails userDetails)
        {
            var user = _mapper.Map<ApiUser>(userDetails);

            user.UserName = userDetails.Email;

            var result = await _userManager.CreateAsync(user, userDetails.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleTypes.User);
            }

            return result.Errors;
        }

        public async Task<AuthResponse?> VerifyRefreshToken(AuthResponse request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.Id != request.UserId)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(user, AppSettings.LoginProviderName, AppSettings.RefreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken(user);

                return new AuthResponse
                {
                    Token = token,
                    UserId = user.Id,
                    RefreshToken = await CreateRefreshToken(user)
                };
            }

            await _userManager.UpdateSecurityStampAsync(user);

            return null;
        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtSettingsKeys.Key]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(IdTypes.User, user.Id)
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration[JwtSettingsKeys.Issuer],
                audience: _configuration[JwtSettingsKeys.Audience],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration[JwtSettingsKeys.Duration])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
