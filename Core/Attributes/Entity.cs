namespace LuaORM.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class EntityAttribute : Attribute
    {
        public string? Name { get; private set; }
        public string? Charset { get; private set; }

        public EntityAttribute(string? name = null, string? charset = null)
        {
            Name = name;
            Charset = charset;
        }
    }
}