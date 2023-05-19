using FluentValidation;
using Microsoft.OpenApi.Models;
using SimApi.Data.Uow;
using SimApi.Service.RestExtension;
using SimpraOdev.Data.Context;
using SimpraOdev.Data.Models;

namespace SimpraOdev;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContextExtension(Configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddRepositoryExtension();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simpra API Management", Version = "v1.0" });
        });

        services.AddSingleton<IValidator<Staff>, StaffFluentValidation>();

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelsExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simpra Bootcamp Homework");
            c.DocumentTitle = "SimpraAPI Documentation";
        });

        app.UseHttpsRedirection();

        // add auth 
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

