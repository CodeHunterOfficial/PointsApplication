using Microsoft.EntityFrameworkCore;
using System;

namespace PointsApplication.Models
{
    public partial class PointsdbContext : DbContext
    {
        public PointsdbContext()
        {
        }

        public PointsdbContext(DbContextOptions<PointsdbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Point> Points { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* optionsBuilder.UseMySql(
                  "server=localhost;user=root;password=еуые;database=pointsdb;",
                  new MySqlServerVersion(new Version(8, 0, 11))
              );*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Point>(entity =>
            {
                entity.ToTable("points");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(25)
                    .HasColumnName("descriptions")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Dt)
                    .HasColumnType("datetime")
                    .HasColumnName("dt");

                entity.Property(e => e.XCoordinate).HasColumnName("xCoordinate");

                entity.Property(e => e.YCoordinate).HasColumnName("yCoordinate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
