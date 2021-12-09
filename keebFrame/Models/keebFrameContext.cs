using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace keebFrame.Models
{
    public partial class keebFrameContext : DbContext
    {
        public keebFrameContext()
        {
        }

        public keebFrameContext(DbContextOptions<keebFrameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning to protect potentially sensitive information in your connection string, you should move it out of source code. see http://go.microsoft.com/fwlink/?linkid=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=keebFrame;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PAnswer)
                    .HasColumnName("pAnswer")
                    .IsUnicode(false);

                entity.Property(e => e.PId)
                    .HasColumnName("pId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PImageId).HasColumnName("pImageId");

                entity.Property(e => e.PQuestion)
                    .HasColumnName("pQuestion")
                    .IsUnicode(false);

                entity.Property(e => e.PTitle)
                    .HasColumnName("pTitle")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
