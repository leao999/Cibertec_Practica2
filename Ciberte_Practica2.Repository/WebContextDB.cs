using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ciberte_Practica2.Model;

namespace Ciberte_Practica2.Repository
{
    public class WebContextDB : DbContext
    {
        //Ciberte_Practica2ConnectionString
        public WebContextDB(): base("Ciberte_Practica2ConnectionString")
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        //public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Album)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoice)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Customer)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.SupportRepId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee1)
                .WithOptional(e => e.Employee2)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceLine)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceLine>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MediaType>()
                .HasMany(e => e.Track)
                .WithRequired(e => e.MediaType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.Track)
                .WithMany(e => e.Playlist)
                .Map(m => m.ToTable("PlaylistTrack").MapLeftKey("PlaylistId").MapRightKey("TrackId"));

            modelBuilder.Entity<Track>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Track>()
                .HasMany(e => e.InvoiceLine)
                .WithRequired(e => e.Track)
                .WillCascadeOnDelete(false);
        }


    }
}
