namespace LuaORM.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class ForeignKeyAttribute : Attribute
    {
        public Type Reference { get; private set; }
        public string FieldName { get; private set; }

        public ForeignKeyAttribute(Type reference, string fieldName)
        {
            Reference = reference;
            FieldName = fieldName;
        }
    }
}