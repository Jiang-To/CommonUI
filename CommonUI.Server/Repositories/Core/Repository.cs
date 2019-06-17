using System.Data;

namespace CommonUI.Server.Repositories {
    public abstract class Repository {
        protected readonly IDbConnection _connection;

        public Repository(IDbConnection connection) {
            _connection = connection;
        }
    }
}