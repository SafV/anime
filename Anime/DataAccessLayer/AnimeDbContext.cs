using AnimeContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AnimeDbContext<T> : DbContext
        where T : class, IDomainObject
    {
        static AnimeDbContext()
        {
            Database.SetInitializer(
                new AnimeDatabaseInitializer<T>()
            );
        }

        public AnimeDbContext()
            : base("name=AnimeDatabase")
        {
        }

        public DbSet<T> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>().ToTable(typeof(T).Name);

            modelBuilder.Entity<T>().HasKey(item => item.Id);

            modelBuilder.Entity<T>()
                .Property(item => item.Id)
                .HasDatabaseGeneratedOption(
                    System.ComponentModel.DataAnnotations.Schema
                        .DatabaseGeneratedOption.None
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
