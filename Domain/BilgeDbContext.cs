using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BilgeDbContext : DbContext

    {

        public DbSet<Ders> Ders { get; set; }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }

        public DbSet<Siniflar> Siniflar { get; set; }
        public DbSet<OgretmenDers> OgretmenDers { get; set; }

        public DbSet<OgrenciSiniflar> OgrenciSiniflar { get; set; }

        public DbSet<Veli> Veli { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public BilgeDbContext()
        {

        }

        public BilgeDbContext(DbContextOptions<BilgeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7I7PU0G;Initial Catalog=BilgeCollegee; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=BilgeDb;User Id=postgres;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OgrenciSiniflar>().HasKey(x => new { x.OgrenciId, x.SiniflarId });
            modelBuilder.Entity<OgrenciSiniflar>().HasOne(x => x.Ogrenci).WithMany(x => x.Siniflar).HasForeignKey(x => x.SiniflarId);
            modelBuilder.Entity<OgrenciSiniflar>().HasOne(x => x.Siniflar).WithMany(x => x.Ogrenci).HasForeignKey(x => x.OgrenciId);


            modelBuilder.Entity<OgretmenDers>().HasKey(x => new { x.DersId, x.OgretmenId });
            modelBuilder.Entity<OgretmenDers>().HasOne(x => x.Ogretmen).WithMany(x => x.Ders).HasForeignKey(x => x.DersId);
            modelBuilder.Entity<OgretmenDers>().HasOne(x => x.Ders).WithMany(x => x.Ogretmen).HasForeignKey(x => x.OgretmenId);


            #region Kullanici
            modelBuilder.Entity<Kullanici>()
                .Property(x => x.UserName)
                .HasMaxLength(20)
                .IsRequired();


            modelBuilder.Entity<Kullanici>()
                .Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Kullanici>()
                .Property(x => x.Role)
                .HasMaxLength(20)
                .HasDefaultValue<string>("user");
            #endregion

            #region Sinif

            #endregion

        }
    }
}
