using CRUDPOC.Shared;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CRUDPOC.Data.Dapper.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private string ConnectionString { get; set; }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public FilmRepository(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public async Task<bool> DeleteFilm(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM Films WHERE id = @id";

            var result = await db.ExecuteAsync(sql.ToString(), new { id });

            return result > 0;
        }

        public async Task<IEnumerable<Film>> GetAllFilms()
        {
            var db = dbConnection();
            var sql = @"SELECT id, Title, Director, ReleaseDate FROM Films";

            return await db.QueryAsync<Film>(sql.ToString(), new { });
        }

        public async Task<Film> GetFilmsDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, Title, Director, ReleaseDate FROM Films WHERE id = @id";

            return await db.QueryFirstAsync<Film>(sql.ToString(), new { id });
        }

        public async Task<bool> InsertFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Films(Title, Director, ReleaseDate)
                    VALUES(@Title, @Director, @ReleaseDate)";

            var result =
                await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate });

            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"UPDATE FILMS
                      SET Title =@Title,
                      Director = @Director,
                      ReleaseDate = @ReleaseDate
                      WHERE id = @id";

            var result =
                await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate, film.Id });

            return result > 0;
        }
    }
}