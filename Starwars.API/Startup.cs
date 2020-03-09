using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Starwars.Model;
using Starwars.Model.Models;
using Starwars.Service;
using Starwars.Service.IServices;
using Starwars.Service.UnitOfWork;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF.Trackable;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
namespace Starwars.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //public object JwtBearerDefaults { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("StarwarsContext");
            services.AddDbContext<StarwarsContext>(options => options.UseSqlServer(connectionString));
            //services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<StarwarsContext>();

            //services.AddDefaultIdentity<IdentityUser>()
            //        .AddRoles<IdentityRole>()
            //        .AddEntityFrameworkStores<StarwarsContext>();

            services.AddMvc();
            services.AddScoped<DbContext, StarwarsContext>();
            services.AddScoped<IStarwarsUnitOfWork, StarwarsUnitOfWork>();
            services.AddScoped(typeof(ITrackableRepository<>), typeof(TrackableRepository<>));
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IFilmsService, FilmsService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // DB Creation and Seeding
            //services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            //services.AddAutoMapper(typeof(Startup));

            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors();
            services.AddMvc() // or `.AddRazorPages`, `.AddControllers`, `.AddControllersWithViews`
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);

            //var key = Encoding.UTF8.GetBytes("somethingyouwantwhichissecurewillworkk");
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.Events = new JwtBearerEvents
            //    {
            //        OnTokenValidated = context =>
            //        {
            //            var userservice = context.HttpContext.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
            //            var userid = context.Principal.Identity.Name;
            //            var user = userservice.FindByIdAsync(userid);
            //            if (user == null)
            //            {
            //                // return unauthorized if user no longer exists
            //                context.Fail("unauthorized");
            //            }
            //            return Task.CompletedTask;
            //        }
            //    };
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(
                options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
