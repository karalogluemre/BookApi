using Framework.AssemblyHelper;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Persistence
{
    public class LibraryDbContext : DbContextBase
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a => { modelBuilder.ApplyConfiguration(a); });

        }


        protected List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyHelper("Books.");
            return assemblyHelper.GetTypes(typeof(EntityMappingBase<>))
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();
        }

    }
}
