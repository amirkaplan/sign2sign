using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sign2sign.api.Models
{
    public partial class sign2signContext : IdentityDbContext
    {
        public sign2signContext()
        {
        }

        public sign2signContext(DbContextOptions<sign2signContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<Window> Windows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=sign2sign.database.windows.net;initial catalog=sign2sign;persist security info=True;user id=amirkaplan;password=Qweasdzxc1@;multipleactiveresultsets=True;application name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "seed data"

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Business", NormalizedName = "BUSINESS" }
            );

            #endregion

            modelBuilder.Entity<Layout>(entity =>
            {
                entity.ToTable("layouts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Window>(entity =>
            {
                entity.ToTable("windows");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LayoutId).HasColumnName("layout_id");

                entity.Property(e => e.Hieght).HasColumnName("hieght");

                entity.Property(e => e.Left).HasColumnName("left");

                entity.Property(e => e.Top).HasColumnName("top");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.Property(e => e.ZIndex).HasColumnName("z_index");
            });
        }
    }
}
