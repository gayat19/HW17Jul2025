
using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Mappers;
using FirstAPI.Models;
using FirstAPI.Repositories;
using FirstAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FirstAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
                  //.AddJsonOptions(options =>
                  //{
                  //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                  //    options.JsonSerializerOptions.WriteIndented = true;
                  //});
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });





            builder.Services.AddAutoMapper(typeof(EmployeeSearchMapperProfile));
            builder.Services.AddDbContext<EmployeeManagementContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });


            //authentication filter / pipe
            #region Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=> {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey =true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:JWT"]))
                    };
                });
            #endregion

            #region RepositoriesInjection
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepositoryDB>();
            builder.Services.AddScoped<IRepository<int, Department>, DepartmentRepositoryDb>();
            builder.Services.AddScoped<IRepository<int, EmployeeStatusMaster>, EmployeeStatusRepository>();
            builder.Services.AddScoped<IRepository<int, DepartmnetStatusMaster>, DepartmentStatusRepository>();
            builder.Services.AddScoped<IRepository<string,User>,UserRepository>();
            #endregion


            #region ServicesInjection
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeDashboardService, EmployeeService>();
            builder.Services.AddScoped<IAuthenticate, AuthenticationService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
