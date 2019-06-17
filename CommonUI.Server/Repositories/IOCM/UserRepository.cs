using System;
using System.Data;
using CommonUI.Server.Models;

namespace CommonUI.Server.Repositories.IOCM {
    public class UserRepository : Repository {
        public UserRepository(IDbConnection connection) : base(connection) { }

        public User GetUserProfileByName(string username) {
            // throw new NotImplementedException();
            return new User {
              UserName = username,
              Roles = new string[]{"Support"}
            };
        }
    }

}