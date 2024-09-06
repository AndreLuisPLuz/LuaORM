namespace LuaORM.Core
{
    public interface IDataSource
    {
        public void CreateMigration();
        public void ExecuteMigration();
    }
}