using FluentMigrator;
using FluentMigrator.SqlServer;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Users
{
    [Migration(202203031310, "CreateUsersTable")]
    [ExcludeFromCodeCoverage]
    public class CreateUsersTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            var random = new Random();
            if (!Schema.Table("Users").Exists()) 
            {
                Create.Table("Users")
                    .WithColumn("UserId").AsInt32().PrimaryKey().Identity(random.Next(12365, 98547), random.Next(3, 10)).NotNullable()
                    .WithColumn("Name").AsString().NotNullable()
                    .WithColumn("Username").AsString().NotNullable()
                    .WithColumn("Password").AsString().NotNullable()
                    .WithColumn("CreatedAt").AsDateTime().NotNullable();
            }
        }
    }
}
