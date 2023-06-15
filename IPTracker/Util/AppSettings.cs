using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Util
{
    public static class AppSettings
    {
        public static string Get(string key)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            var config = configuration.Build();
            var keyObtained = config.GetSection(key);

            if (keyObtained != null)
            {
                return keyObtained.Value;
            }

            return "";
        }
    }
}
