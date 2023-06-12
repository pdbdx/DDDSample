using System.Configuration;

namespace DDDExample
{
    /// <summary>
    /// Shared
    /// </summary>
    public class AppSettings
    {
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
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
