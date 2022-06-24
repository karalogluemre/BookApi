using Microsoft.EntityFrameworkCore;

namespace Books.ReadModel.Context.Models
{
    public partial class LibraryContext
    {
        public virtual DbSet<BookInformation> BookInformations { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookInformation>(e =>
            {
                e.HasNoKey();
            });
        }

    }
}
