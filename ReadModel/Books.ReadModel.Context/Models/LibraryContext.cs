using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Books.ReadModel.Context.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<SubType> SubTypes { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =.; initial catalog = Library; integrated security = SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author", "BookContext");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book", "BookContext");

                entity.HasIndex(e => e.AuthorId, "IX_Book_AuthorId");

                entity.HasIndex(e => e.SubTypeId, "IX_Book_SubTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.SubType)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.SubTypeId);
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("Reader", "BookContext");

                entity.HasIndex(e => e.BookId, "IX_Reader_BookId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Readers)
                    .HasForeignKey(d => d.BookId);
            });

            modelBuilder.Entity<SubType>(entity =>
            {
                entity.ToTable("SubType", "BookContext");

                entity.HasIndex(e => e.TypeId, "IX_SubType_TypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.SubTypes)
                    .HasForeignKey(d => d.TypeId);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type", "BookContext");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
