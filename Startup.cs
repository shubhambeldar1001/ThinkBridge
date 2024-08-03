using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;
using Microsoft.OpenApi.Models;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Services;

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

        services.AddSwaggerGen();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add scoped services for repositories and services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<ITaskRepository, TaskRepository>();


        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<ITeamRepository, TeamRepository>();

        services.AddScoped<ITeamMemberService, TeamMemberService>();
        services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            /*   // Enable Swagger middleware in development environment
               app.UseSwagger();
               app.UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management API V1");
                   c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
               });
           */
        }

        app.UseSwagger();

        // Enable Swagger-UI Middleware.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPICore");
        });

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
