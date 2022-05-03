
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.FilmGenre
{
    [Migration(302203031313, "CreateFilmGenreTable")]
    [ExcludeFromCodeCoverage]
    public class CreateFIlmGenreTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (true)
            {
                Create.Table("FilmGenre")
                    .WithColumn("FilmId").AsInt32().NotNullable().ForeignKey("Films", "FilmId").OnDelete(System.Data.Rule.Cascade)
                    .WithColumn("GenreId").AsInt32().NotNullable().ForeignKey("Genres", "GenreId").OnDelete(System.Data.Rule.Cascade);
            }
        }
    }
}
