using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AnimeDatabaseInitializer<T>
        : IDatabaseInitializer<AnimeDbContext<T>>
        where T : class, AnimeContracts.IDomainObject
    {
        public void InitializeDatabase(AnimeDbContext<T> context)
        {
            string sql = @"
                IF OBJECT_ID(N'[dbo].[Anime]', N'U') IS NULL
                BEGIN
                    CREATE TABLE [dbo].[Anime]
                    (
                        [Id] INT NOT NULL PRIMARY KEY,
                        [Title] NVARCHAR(200) NOT NULL,
                        [Genre] NVARCHAR(100) NOT NULL,
                        [Year] INT NOT NULL,
                        [Episodes] INT NOT NULL
                    )
                END";

            context.Database.ExecuteSqlCommand(sql);
        }
    }
}
