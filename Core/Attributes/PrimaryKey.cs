namespace LuaORM.Core.Attributes
{
    public enum GenerationStrategy
    {
        AUTOGENERATE,
        MANUAL
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class PrimaryKeyAttribute : Attribute
    {
        public GenerationStrategy Strategy { get; private set; }

        public PrimaryKeyAttribute(GenerationStrategy? strategy)
        {
            Strategy = strategy ?? GenerationStrategy.AUTOGENERATE;
        }
    }
}