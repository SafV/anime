using AnimeContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using AnimeLogic;


namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Anime>
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["AnimeDatabase"].ConnectionString;

        public DapperRepository()
        {
            using (var context = new AnimeDbContext<Anime>())
            {
                context.Database.Initialize(false);
            }
        }
        public void Add(Anime item)
        {
            string sql = @"INSERT INTO Anime
                           (Id, Title, Genre, Year, Episodes)
                           VALUES
                           (@Id, @Title, @Genre, @Year, @Episodes)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, item);
            }
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Anime WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, new { Id = id });
            }
        }

        public List<Anime> ReadAll()
        {
            string sql = "SELECT * FROM Anime";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Anime>(sql).ToList();
            }
        }

        public Anime ReadById(int id)
        {
            string sql = "SELECT * FROM Anime WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QueryFirstOrDefault<Anime>(
                    sql, new { Id = id });
            }
        }

        public void Update(Anime item)
        {
            string sql = @"UPDATE Anime
                           SET Title = @Title,
                               Genre = @Genre,
                               Year = @Year,
                               Episodes = @Episodes
                           WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql, item);
            }
        }
    }
}
