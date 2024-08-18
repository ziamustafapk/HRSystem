using FluentValidation;
using FluentValidation.AspNetCore;
using HRSystem.Server.DataAccess.DataContext;
using HRSystem.Server.DataAccess.Repositories;
using HRSystem.Server.DataTransferObjects.Application.Employee;
using HRSystem.Server.DataTransferObjects.Application.Overtime;
using HRSystem.Server.DataTransferObjects.Application.Vacation;
using HRSystem.Server.Entities.Admin;
using HRSystem.Server.Entities.Configuration;
using HRSystem.Server.Models;
using HRSystem.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace HRSystem.Server.Api.Extensions
{
    public static class ServiceExtensions
    {
        // Cors Configuration
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination"));
            });

        // Repository Manager Configuration
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        // Service Manager Configuration
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        // SQL Server Configuration
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<HrSystemDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            );

        // Fluent Validation Configuration
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<DepartmentForManipulationDto>, DepartmentForManipulationValidator>();
            services.AddScoped<IValidator<EmployeeForManipulationDto>, EmployeeForManipulationValidator>();
            services.AddScoped<IValidator<OvertimeForManipulationDto>, OvertimeForManipulationValidator>();
            services.AddScoped<IValidator<VacationForManipulationDto>, VacationForManipulationValidator>();
        }

        // Identity Configuration
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<ApplicationUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 8;
                o.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<HrSystemDbContext>()
                .AddDefaultTokenProviders();
        }

        // JWT Token Configuration
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

            
            var secretKey = jwtConfiguration.Secret; 

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtConfiguration.ValidIssuer, 
                        ValidAudience = jwtConfiguration.ValidAudience, 
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });
        }

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
        }

        // Swagger Configuration
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            //Register the Swagger generator, defining 1 or more Swagger documents
            var commonDescription = "**Type here your swagger login page title**";
            var swaggerAuthenticatedDescription = commonDescription;
            swaggerAuthenticatedDescription += "\r\n";
            swaggerAuthenticatedDescription += "\r\nType here your swagger page description";

            var swaggerDescription = commonDescription;
            swaggerDescription += "\r\n";
            swaggerDescription += "\r\nTo access integration api login with user: demo password: demo";

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HR System API",
                    Version = "v1",
                    Description = swaggerDescription, //"An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Email = "info@codedesigntips.com",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });


               
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",

                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });

                //Resolve apiDescriptions conflict
                s.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


            });
        }



    }
}
