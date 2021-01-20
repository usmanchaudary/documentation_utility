using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace word_html_utility.Models
{
    public partial class wordversionsContext : DbContext
    {
        public wordversionsContext()
        {
        }

        public wordversionsContext(DbContextOptions<wordversionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tableofcontent> Tableofcontent { get; set; }
        public virtual DbSet<TemplateVersion> TemplateVersion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=desktop-vd5sscb;Initial Catalog=wordversions;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tableofcontent>(entity =>
            {
                entity.ToTable("tableofcontent");

                entity.Property(e => e.Templateid).HasColumnName("templateid");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Tableofcontent)
                    .HasForeignKey(d => d.Templateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TableofContent_TemplateVersion");
            });

            modelBuilder.Entity<TemplateVersion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlternateExample).HasColumnName("alternate_example");

                entity.Property(e => e.AlternateExamplesExplanation).HasColumnName("alternate_examples_explanation");

                entity.Property(e => e.ExampleExaplanation).HasColumnName("example_exaplanation");

                entity.Property(e => e.FunctionDescription).HasColumnName("function_description");

                entity.Property(e => e.FunctionExample).HasColumnName("function_example");

                entity.Property(e => e.FunctionName).HasColumnName("function_name");

                entity.Property(e => e.ImagePath).HasColumnName("image_path");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
