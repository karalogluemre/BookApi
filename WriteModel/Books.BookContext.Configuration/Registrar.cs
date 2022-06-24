﻿using Framework.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Books.BookContext.Configuration
{
    public class Registrar : RegistrarBase<Registrar>, IRegistrar
    {
        public override void Register(IServiceCollection services, string connectionString)
        {
            base.Register(services, connectionString);
        }
    }
}
