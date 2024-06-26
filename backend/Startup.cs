using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using LibraryBackend.Database;
using System.Reflection;
using StackExchange.Redis;

namespace LibraryBackend {

    /// <summary>
    /// Описание конфигурации приложения
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса Startup с указанной конфигурацией.
        /// </summary>
        /// <param name="configuration">Объект, представляющий интерфейс IConfiguration, содержащий конфигурационные данные приложения.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Конфигурация приложения.
        /// </summary>
        public IConfiguration Configuration { get; }
        
        /// <summary>
        /// Настраивает службы, необходимые для работы приложения.
        /// </summary>
        /// <param name="services">Коллекция служб, которые будут настроены.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDataBase(services);
            ConfigureIdentity(services);
            ConfigureAuthentication(services);
            ConfigureSwagger(services);
            ConfigureSession(services);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddHealthChecks();
            services.AddControllers();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "LibraryBackend";
            });
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var configuration = "localhost:6379";
                return ConnectionMultiplexer.Connect(configuration);
            });
        }

        private void ConfigureDataBase(IServiceCollection services) {
            string? connectionString = Configuration.GetConnectionString("PostgresConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        }

        private void ConfigureIdentity(IServiceCollection services) {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var jwtSettings = Configuration.GetSection("JWT");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
        }

        private void ConfigureAuthentication(IServiceCollection services) 
        {
            var jwtSettings = Configuration.GetSection("JWT");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["ValidIssuer"],
                    ValidAudience = jwtSettings["ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kegostrov Library LibraryBackend Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        }

        private void ConfigureSession(IServiceCollection services) {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(8);
            });
        }

        /// <summary>
        /// Конфигурирует приложение для обработки запросов и управления их маршрутизацией.
        /// </summary>
        /// <param name="app">Объект, представляющий построитель приложения ASP.NET Core.</param>
        /// <param name="env">Объект, представляющий среду выполнения веб-приложения.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
            }
            else
            {
                app.UseExceptionHandler();
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kegostrov Library LibraryBackend Api v1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }

}