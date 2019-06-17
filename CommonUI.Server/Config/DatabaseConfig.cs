namespace CommonUI.Server.Config {
    public class DatabaseConfig {
        // private readonly string _iocm;
        // private readonly string _ods;

        // public DatabaseConfig(string iocmConnectionString, string odsConnectionString) {
        //     _iocm = iocmConnectionString;
        //     _ods = odsConnectionString;
        // }

        // public string IocmConnectionString => _iocm;
        // public string OdsConnectionString => _ods;

        public string IocmConnectionString { get; set; } 
        public string OdsConnectionString { get; set; }
    }

}