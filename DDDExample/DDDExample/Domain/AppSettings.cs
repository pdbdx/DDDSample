using System.Configuration;

namespace DDDExample.Domain
{
    /// <summary>
    /// Shared
    /// </summary>
    public class AppSettings
    {
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + @"\Domain")
                .AddJsonFile("appSettings.json");
            var configuration = builder.Build();

            DbKind = configuration.GetValue<int>("DbKind");
            MySQLConnectionString = configuration.GetValue<string>("MySQLConnectionString") ?? string.Empty;
        }

        /// <summary>
        /// Fakeの時True
        /// </summary>
        public int DbKind { get; }

        public string MySQLConnectionString { get; }

    }
}
