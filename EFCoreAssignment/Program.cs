using Company.Application.Abstractions.Services;
using Company.Domain.Repositories;
using Company.Infrastructure;
using Company.Infrastructure.Services;
using Company.Persistence;
using Company.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Company.Application.DTOs.DepartmentDTO;
using Company.Application.Validator;
using Company.Application.DTOs.EmployeeDTO;
using Company.Application.DTOs.SalaryDTO;

namespace EFCoreAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();

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
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();

            // Register FluentValidation
            builder.Services.AddScoped<IValidator<DepartmentRequestDTO>, DepartmentDTOValidator>();
            builder.Services.AddScoped<IValidator<EmployeeRequestDTO>, EmployeeDTOValidator>();
            builder.Services.AddScoped<IValidator<SalaryRequestDTO>, SalaryDTOValidator>();

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
