﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taskter.Api;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.Shared;

namespace Taskter.Tests.Helpers.Factories
{
    public class IntegrationWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<TaskterDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TaskterInMemoryDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.RegisterIoCDependencies();

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TaskterDbContext>();

                    db.Database.EnsureCreated();
                }
            });
        }
    }
}
