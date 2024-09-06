namespace LuaORM.Core.Analysis
{
    public class MigrationEntity
    {
        public string Name { get; set; }
        public string Charset { get; set; }
        public Type Class { get; set; }
        public HashSet<MigrationColumn> Columns { get; set; }

        public MigrationEntity(string name, Type @class, string charset = "utf8")
        {
            Name = name;
            Class = @class;
            Charset = charset;
            Columns = [];
        }
    }
}