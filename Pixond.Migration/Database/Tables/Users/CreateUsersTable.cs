using FluentMigrator;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Users
{
    [Migration(302202010109, "Create Users Table")]
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
            if (true) 
            {
                Create.Table("Users")
                    .WithColumn("UserId").AsGuid().PrimaryKey().NotNullable()
                    .WithColumn("FirstName").AsString(500).NotNullable()
                    .WithColumn("LastName").AsString(500).NotNullable()
                    .WithColumn("Email").AsString(300).NotNullable()
                    .WithColumn("Username").AsString(200).NotNullable()
                    .WithColumn("Password").AsString(500).NotNullable()
                    .WithColumn("CreatedAt").AsDateTime().NotNullable()
                    .WithColumn("CreatedBy").AsString(500).NotNullable()
                    .WithColumn("ModifiedAt").AsDateTime().Nullable()
                    .WithColumn("ModifiedBy").AsString(500).Nullable();
            }
        }
    }
}
