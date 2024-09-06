namespace LuaORM.Core.Connection
{
    public class SqlServerDataConnector : IDataConnector
    {
        public string ConnectionString(
                string host,
                string port,
                string name,
                string? user = null,
                string? pass = null)
        {
            if (user is not null && pass is not null)
                return $"Server={host};Database={name};User Id={user};Password={pass};";

            return $"Server={host};Database={name};Trusted_Connection=True;";
        }
    }
}