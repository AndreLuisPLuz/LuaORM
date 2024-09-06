namespace LuaORM.Core
{
    public interface IDataConnector
    {
        public string ConnectionString(
            string host,
            string port,
            string name,
            string? user,
            string? pass
        );
    }
}