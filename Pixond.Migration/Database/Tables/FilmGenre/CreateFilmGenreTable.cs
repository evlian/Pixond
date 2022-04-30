
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.FilmGenre
{
    [Migration(202203031313, "CreateFilmGenreTable")]
    [ExcludeFromCodeCoverage]
    public class CreateFIlmGenreTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Table("FilmGenre").Exists())
            {
                Create.Table("FilmGenre")
                    .WithColumn("FilmId").AsInt32().NotNullable().ForeignKey("Films", "FilmId")
                    .WithColumn("GenreId").AsInt32().NotNullable().ForeignKey("Genres", "GenreId");
            }
        }
    }
}
