using System;

using Domain.Model.Repository;

using Infrastructure.Data;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ServerlessFnApp.Startup))]
namespace ServerlessFnApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContextPool<DomainDbContext>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("CONECTIONSTRING"));
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}