using Microsoft.Extensions.Configuration;

namespace EMPDAL
{
    public class ConfigHelper
    {
        public static string GetConfiguration(string MainKey, string SubKey)
        {
            return Configuration.GetSection(MainKey).GetValue<string>(SubKey);
        }

        public static string GetAppSettings(string SubKey)
        {
            return Configuration.GetSection("AppSettings").GetValue<string>(SubKey);
        }

        #region Properties
        private static IConfigurationRoot? _configuration;

        private static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .AddEnvironmentVariables().Build();
                return _configuration;
            }
        }
        #endregion
    }
}
