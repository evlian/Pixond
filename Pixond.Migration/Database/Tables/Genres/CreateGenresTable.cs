using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Genres
{
    [Migration(202203031311, "CreateGenresTable")]
    [ExcludeFromCodeCoverage]
    public class CreateGenresTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            var random = new Random();
            Create.Table("Genres")
                .WithColumn("GenreId").AsInt32().PrimaryKey().NotNullable().Identity(random.Next(12365, 98547), random.Next(3, 10))
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("CreatedBy").AsString(500).NotNullable()
                .WithColumn("CreatedAt").AsDateTime()
                .WithColumn("ModifiedBy").AsString(500).Nullable()
                .WithColumn("ModifiedAt").AsDateTime().Nullable();
        }
    }
}
