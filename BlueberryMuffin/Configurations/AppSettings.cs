namespace BlueberryMuffin.Configurations
{
    public static class JwtSettingsKeys
    {
        public const string Key = "JwtSettings:Key";
        public const string Issuer = "JwtSettings:Issuer";
        public const string Audience = "JwtSettings:Audience";
        public const string Duration = "JwtSettings:DurationInMinutes";
    }

    public static class AppSettings
    {
        public const string LoginProviderName = "BlueberryAPI";
        public const string RefreshToken = "RefreshToken";
    }
}
