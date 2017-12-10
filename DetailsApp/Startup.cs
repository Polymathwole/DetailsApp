using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DetailsApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DetailsApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
           Configuration = configuration;

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));//EF setup to persist users 
            services.AddMvc();

            services.AddIdentity<User, IdentityRole>(options=> {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();//Identity setup for user authentication

            services.AddTransient<IUsers, EFUsersRepo>();//service to get users from the db
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default","{controller=Account}/{action=Login}/{id?}");
                routes.MapRoute("defaultl", "login", new { controller = "Account", action = "Login" });
                routes.MapRoute("", "user/signup", new { controller = "User", action = "Signup" });
            });
        }
    }
}
