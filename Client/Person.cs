using LuaORM.Core.Attributes;

namespace LuaORM.Client
{
    [Entity("person", "utf8")]
    public class Person
    {
        [PrimaryKey(GenerationStrategy.AUTOGENERATE)]
        [Column("id", Core.Definitions.DbTypes.INTEGER)]
        public int Id { get; set; }

        [Column("name", Core.Definitions.DbTypes.VARCHAR, 255)]
        public string Name { get; set; }
    }
}