
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;
using Talabat.Core.Models.Identity;
using Talabat.Error;
using Talabat.Extenstions;
using Talabat.Helper;
using Talabat.Middlewares;
using Talabat.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Data.DataSeed;
using Talabat.Repository.Identity;
using Talabat.Repository.Identity.DataSeed;

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }) ;

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnectionString"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(op => { op.Lockout.MaxFailedAccessAttempts = 5;
            op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
            op.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            #region Redis

            builder.Services.AddSingleton<IConnectionMultiplexer>(op =>
            {
                var connection = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });
            #endregion
            builder.Services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddApplicationServices();

            builder.Services.AddSwaggerServices();



            var app = builder.Build();


            var scope = app.Services.CreateScope();   // create scope (life time) (create range of time to use services)

            #region UpdateDataBase
            try
            {
                var Service = scope.ServiceProvider;  // call container which have all services
                var _dbcontext = Service.GetRequiredService<StoreContext>();  // call clr to create object instanse from storedbcontext
                var _identitycontext = Service.GetRequiredService<AppIdentityDbContext>();
                var LoggerFactory= Service.GetRequiredService<ILoggerFactory>();  // log excption

                try
                {
                    await _dbcontext.Database.MigrateAsync(); //update -database
                    await _identitycontext.Database.MigrateAsync();

                    await StoreContextSeed.SeedAsync(_dbcontext);  //seed data 
                    var user = Service.GetRequiredService<UserManager<AppUser>>();
                    await AppIdentityDbContextSeed.SeedAsync(user);


                }
                catch (Exception ex)
                {
                 var logger =LoggerFactory.CreateLogger<Program>();
                    logger.LogError(ex,"an error has been occured during apply the migration");
                }
            
            }
            finally
            {
                scope.Dispose();
            }

            #endregion

            #region Server error middleware

            app.UseMiddleware<ExceptionMiddleware>();

            #endregion
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleWare();
            }
              
                
           

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
