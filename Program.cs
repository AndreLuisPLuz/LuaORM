using LuaORM.Core.Sources;

var datasource = new SqlServerDataSource();
datasource.CreateMigration();
datasource.ExecuteMigration();