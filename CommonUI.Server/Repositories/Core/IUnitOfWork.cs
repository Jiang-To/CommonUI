namespace CommonUI.Server.Repositories {
    public interface IUnitOfWork{
        void BeginTransaction();
        void CommitTransaction();
    }
}