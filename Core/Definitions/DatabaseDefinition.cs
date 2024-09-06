namespace LuaORM.Core.Definitions
{
    public class DatabaseDefinition
    {
        public DbTypes Type { get; set; }
        public int? Size { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
    }
}