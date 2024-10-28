using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace ExportEmployeesToPmc
{
    internal static class AppConfiguration
    {

        public static string GetConnectionString(string connectionname)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load the appsettings.json file
                .Build();

            return configuration.GetConnectionString(connectionname);
        }
    }
}
