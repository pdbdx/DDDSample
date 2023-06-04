using System.Configuration;

namespace DDDExample.Domain
{
    /// <summary>
    /// Shared
    /// </summary>
    public class AppSettings
    {
        public AppSettings() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json");
            var configuration = builder.Build();

            this.IsDummy = configuration.GetValue<int>("IsDummy");
            this.MySQLConnectionString = configuration.GetValue<string>("MySQLConnectionString") ?? string.Empty;
        }

        /// <summary>
        /// Fakeの時True
        /// </summary>
        public int IsDummy { get; }

        public string MySQLConnectionString { get; }

    }
}
