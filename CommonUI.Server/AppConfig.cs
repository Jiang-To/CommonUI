using Microsoft.Extensions.Configuration;

namespace CommonUI.Server {
    public class AppConfig {

        private readonly DatabaseConfig _dbConfig;
        public DatabaseConfig Database => _dbConfig;

        private readonly LoggerConfig _loggerConfig;
        public LoggerConfig Logger => _loggerConfig;

        public AppConfig(IConfiguration config) {
            _dbConfig = new DatabaseConfig();
            config.Bind("Database", _dbConfig);

            _loggerConfig = new LoggerConfig();
            _loggerConfig.Level = config.GetValue<string>("Logging:LogLevel:Default");
        }
    }
    public class DatabaseConfig {
        public string IocmConnectionString { get; set; }
        public string OdsConnectionString { get; set; }
    }
    public class LoggerConfig {
        public string Level { get; set; }
    }
}