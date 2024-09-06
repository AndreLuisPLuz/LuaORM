using System.Data.SqlClient;
using LuaORM.Core.Analysis;
using LuaORM.Core.Connection;

namespace LuaORM.Core.Sources
{
    public class SqlServerDataSource : IDataSource
    {
        public string CreationQuery { get; set; }

        public void CreateMigration()
        {
            string query = "";
            var entities = MigrationAnalyzer.GetInstance().Entities;

            Console.WriteLine("Contagem entidades: " + entities.Count());
            foreach (var entity in entities)
            {
                var fields = String.Join(",", CreateLines(entity.Columns));
                query += $"CREATE TABLE {entity.Name} ( {fields} );";
            }

            Console.WriteLine("query: " + query);
            CreationQuery = query;
        }

        private IEnumerable<string> CreateLines(IEnumerable<MigrationColumn> columns)
        {
            foreach (var column in columns)
            {
                string line = $" {column.Name} {column.Definition.Type}";

                line += (column.Definition.Size != 0)
                    ? $"({column.Definition.Size}) "
                    : " ";

                line += "NOT NULL";
                
                yield return line;
            }
        }

        public void ExecuteMigration()
        {
            var connector = new SqlServerDataConnector();
            var connectionString = connector.ConnectionString("CA-C-0064T\\SQLEXPRESS", "1433", "Lua");

            Console.WriteLine(connectionString);

            var conn = new SqlConnection(connectionString);
            conn.Open();

            var comm = new SqlCommand(CreationQuery)
            {
                Connection = conn
            };

            comm.ExecuteReader();

            conn.Close();
        }
    }
}