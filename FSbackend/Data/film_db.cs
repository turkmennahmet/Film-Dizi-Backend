using FSbackend.Entities;
using Microsoft.EntityFrameworkCore;


namespace FSbackend.Data
{
    public class film_db : DbContext
    {


        public film_db(DbContextOptions<film_db> options)
            : base(options)
        {
        }
        public DbSet<films> films { get; set; }
        public DbSet<series> series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<films>().HasKey(a => a.id);
            modelBuilder.Entity<series>().HasKey(a => a.id);
            modelBuilder.Entity<films>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.ToTable("films");
            });

            modelBuilder.Entity<series>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.ToTable("series");
            });
        }

    }
        
}
