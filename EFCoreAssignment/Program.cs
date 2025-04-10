using Company.Application.Abstractions.Services;
using Company.Domain.Repositories;
using Company.Infrastructure;
using Company.Infrastructure.Services;
using Company.Persistence;
using Company.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Register the repositories
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Assuming you have a generic repository
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();
            builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();

            //Register Automapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //Register the services
            builder.Services.AddScoped(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
