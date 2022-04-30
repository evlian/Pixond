using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Films
{
    [Migration(202203031312, "CreateFilmsTable")]
    [ExcludeFromCodeCoverage]
    public class CreateFilmsTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Table("Films").Exists())
            {
                var random = new Random();
                Create.Table("Films")
                    .WithColumn("FilmId").AsInt32().PrimaryKey().NotNullable().Identity(random.Next(12365, 98547), random.Next(3, 10))
                    .WithColumn("Title").AsString().NotNullable()
                    .WithColumn("Description").AsString().Nullable()
                    .WithColumn("Director").AsString().NotNullable()
                    .WithColumn("ReleaseDate").AsDate().Nullable()
                    .WithColumn("Length").AsInt32().Nullable()
                    .WithColumn("CreatedBy").AsInt32().Nullable().ForeignKey("Users", "UserId")
                    .WithColumn("CreatedAt").AsDateTime().NotNullable()
                    .WithColumn("ModifiedBy").AsInt32().Nullable().ForeignKey("Users", "UserId")
                    .WithColumn("ModifiedAt").AsDateTime().Nullable();
                    
            }
        }
    }
}
