using LuaORM.Core.Definitions;

namespace LuaORM.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class ColumnAttribute : Attribute
    {
        public string? DbName { get; private set; }
        public DatabaseDefinition Definition { get; private set; }

        public ColumnAttribute(string name, DbTypes type, int? size)
        {
            DbName = name;
            Definition = new DatabaseDefinition
            {
                Type = type,
                Size = size
            };
        }
    }
}