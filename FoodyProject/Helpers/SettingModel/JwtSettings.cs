using System;

namespace FoodyProject.Helpers.SettingModel
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}