namespace CommonUI.Server.Models {
    public class User {
        public string UserName { get; set; }
        public string[] AllowedSubsystem {get;set;}
        public string[] Roles { get; set; }
    }
}