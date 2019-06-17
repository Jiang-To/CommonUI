using System;
using System.Data;
using System.Data.SqlClient;

namespace CommonUI.Server.Repositories.IOCM {
    public class IocmUnitOfWork : UnitOfWork {

        private ScheduleRepository _scheduleRepository;
        private UserRepository _userRepository;

        public IocmUnitOfWork(AppConfig config):
            base(config.Database.IocmConnectionString) { }

        public ScheduleRepository ScheduleRepository {
            get {
                return _scheduleRepository ?? (_scheduleRepository = new ScheduleRepository(_connection));
            }
        }

        public UserRepository UserRepository {
            get {
                return _userRepository ?? (_userRepository = new UserRepository(_connection));
            }
        }

    }

}