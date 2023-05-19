using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpraOdev.Data.Context;
public static class DbContextExtension
{
    public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
    {
    
            var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<SimpraDbContext>(opts =>
            opts.UseSqlServer(dbConfig));

    }
}
