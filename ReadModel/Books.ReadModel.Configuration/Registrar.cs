using Books.ReadModel.Context.Models;
using Books.ReadModel.Queries.Contracts.Books;
using Books.ReadModel.Queries.Facade.Books;
using Framework.Core.Mapper;
using Framework.DependencyInjection;
using Framework.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Books.ReadModel.Configuration
{
    public class Registrar : IRegistrar
    {
        public void Register(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LibraryContext>(op =>
            {
                op.UseSqlServer(connectionString);
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);
            services.AddSingleton<IMapper, Mapper>();
            services.AddScoped<IBooksQueryFacade, BooksQueryFacade>();
        }
    }
}
