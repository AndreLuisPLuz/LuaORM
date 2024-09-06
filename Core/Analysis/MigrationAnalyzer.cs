using System.Collections;
using LuaORM.Core.Attributes;

namespace LuaORM.Core.Analysis
{
    public class MigrationAnalyzer
    {
        private static MigrationAnalyzer? analyzer;
        private readonly HashSet<MigrationEntity> _entities = [];

        public IEnumerable<MigrationEntity> Entities => _entities;

        private MigrationAnalyzer()
        {
            Analyze();
        }

        public static MigrationAnalyzer GetInstance()
        {
            analyzer ??= new();
            return analyzer;
        }

        public void Analyze()
        {
            var entityClasses = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.GetCustomAttributes(true)
                        .Any(a => a is EntityAttribute));

            Console.WriteLine("Entity classes count: " + entityClasses.Count());
            
            if (entityClasses is null || !entityClasses.Any())
                return;

            foreach (var @class in entityClasses)
            {
                var attribute = (EntityAttribute) @class.GetCustomAttributes(
                            typeof(EntityAttribute),
                            false)
                        .First();
                
                var entityName = attribute.Name ?? @class.Name;
                var entityCharset = attribute.Charset ?? "utf8";

                _entities.Add(new MigrationEntity(
                    entityName, @class, entityCharset));
            }

            foreach (var entity in _entities)
                entity.Columns = FillColumns(entity);
        }

        private static HashSet<MigrationColumn> FillColumns(MigrationEntity entity)
        {
            var columnProperties = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.Equals(entity.Class))
                    .SelectMany(c => c.GetProperties())
                    .Where(p => p.GetCustomAttributes(
                        typeof(ColumnAttribute),
                        false) != null);
            
            HashSet<MigrationColumn> columns = [];
            foreach (var prop in columnProperties)
            {
                var attribute = (ColumnAttribute) prop.GetCustomAttributes(
                        typeof(ColumnAttribute),
                        false)
                    .First();
                
                var columnName = attribute.DbName;
                var columnDefiniton = attribute.Definition;

                columns.Add(new MigrationColumn(
                    columnName ?? prop.Name,
                    columnDefiniton));
            }

            return columns;
        }
    }
}