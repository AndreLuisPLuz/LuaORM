namespace LuaORM.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class ForeignKeyAttribute : Attribute
    {
        public string ReferenceName { get; private set; }
        public string FieldName { get; private set; }

        public ForeignKeyAttribute(Type reference, string fieldName)
        {
            FieldName = fieldName;

            var refEntity = (ColumnAttribute) reference.GetCustomAttributes(
                        typeof(ColumnAttribute),
                        false)
                    .First();

            ReferenceName = refEntity.DbName ?? reference.Name;
        }
    }
}