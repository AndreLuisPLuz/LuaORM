using LuaORM.Core.Definitions;

namespace LuaORM.Core.Analysis
{
    public class MigrationColumn
    {
        public string Name { get; set; }
        public DatabaseDefinition Definition { get; set; }

        public MigrationColumn(string name, DatabaseDefinition definition)
        {
            Name = name;
            Definition = definition;
        }
    }
}