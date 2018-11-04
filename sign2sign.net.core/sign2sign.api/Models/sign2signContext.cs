using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sign2sign.api.Models
{
    public partial class sign2signContext : DbContext
    {
        public sign2signContext()
        {
        }

        public sign2signContext(DbContextOptions<sign2signContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Businesses> Businesses { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<Layouts> Layouts { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<Played> Played { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Playlists> Playlists { get; set; }
        public virtual DbSet<Promotions> Promotions { get; set; }
        public virtual DbSet<Screens> Screens { get; set; }
        public virtual DbSet<Windows> Windows { get; set; }

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
            modelBuilder.Entity<Businesses>(entity =>
            {
                entity.ToTable("businesses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(250);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(128);

                entity.Property(e => e.WebSite)
                    .HasColumnName("web_site")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.InverseCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("content");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Html).HasColumnName("html");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.Public).HasColumnName("public");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.Property(e => e.Video)
                    .HasColumnName("video")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_content_Businesses");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_content_Categories");
            });

            modelBuilder.Entity<Layouts>(entity =>
            {
                entity.ToTable("layouts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Art).HasColumnName("art");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.Template)
                    .IsRequired()
                    .HasColumnName("template");
            });

            modelBuilder.Entity<Partners>(entity =>
            {
                entity.ToTable("partners");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            });

            modelBuilder.Entity<Played>(entity =>
            {
                entity.ToTable("played");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");

                entity.Property(e => e.WindowId).HasColumnName("window_id");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.Played)
                    .HasForeignKey(d => d.PlaylistId)
                    .HasConstraintName("FK_played_playlists");

                entity.HasOne(d => d.Window)
                    .WithMany(p => p.Played)
                    .HasForeignKey(d => d.WindowId)
                    .HasConstraintName("FK_played_Windows");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.BusinessId)
                    .HasConstraintName("FK_players_Businesses");
            });

            modelBuilder.Entity<Playlists>(entity =>
            {
                entity.ToTable("playlists");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.Public).HasColumnName("public");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_playlists_Businesses");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_playlists_content");
            });

            modelBuilder.Entity<Promotions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.BusinessId, e.CategotyId });

                entity.ToTable("promotions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BusinessId).HasColumnName("business_id");

                entity.Property(e => e.CategotyId).HasColumnName("categoty_id");

                entity.Property(e => e.Allow).HasColumnName("allow");

                entity.Property(e => e.Deny).HasColumnName("deny");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_promotions_Businesses");

                entity.HasOne(d => d.Categoty)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.CategotyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_promotions_Categories");
            });

            modelBuilder.Entity<Screens>(entity =>
            {
                entity.ToTable("screens");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasMaxLength(50);

                entity.Property(e => e.LayoutId).HasColumnName("layout_id");

                entity.Property(e => e.Loaction)
                    .HasColumnName("loaction")
                    .HasMaxLength(250);

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.HasOne(d => d.Layout)
                    .WithMany(p => p.Screens)
                    .HasForeignKey(d => d.LayoutId)
                    .HasConstraintName("FK_Screens_Layouts");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Screens)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_Screens_players");
            });

            modelBuilder.Entity<Windows>(entity =>
            {
                entity.ToTable("windows");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Hieght).HasColumnName("hieght");

                entity.Property(e => e.LayoutId).HasColumnName("layout_id");

                entity.Property(e => e.Left).HasColumnName("left");

                entity.Property(e => e.PlaylistId).HasColumnName("playlist_id");

                entity.Property(e => e.Top).HasColumnName("top");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.Property(e => e.ZIndex).HasColumnName("z_index");

                entity.HasOne(d => d.Layout)
                    .WithMany(p => p.Windows)
                    .HasForeignKey(d => d.LayoutId)
                    .HasConstraintName("FK_Windows_Layouts");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.Windows)
                    .HasForeignKey(d => d.PlaylistId)
                    .HasConstraintName("FK_Windows_playlists");
            });
        }
    }
}
