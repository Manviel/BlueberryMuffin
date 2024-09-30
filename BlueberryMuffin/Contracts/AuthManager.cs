using AutoMapper;
using BlueberryMuffin.Data;
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
        Task<AuthResponse> Login(LoginDetails loginDetails);
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

        public async Task<AuthResponse> Login(LoginDetails loginDetails)
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
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(AccountDetails userDetails)
        {
            var user = _mapper.Map<ApiUser>(userDetails);

            user.UserName = userDetails.Email;

            var result = await _userManager.CreateAsync(user, userDetails.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
