using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using OnlineVotingApplication.Areas.Identity.Data;
using OnlineVotingApplication.Data;
using System.Configuration;

namespace OnlineVotingApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<OnlineVotingApplicationContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("OnlineVotingApplicationContextConnection")));

            services.AddDefaultIdentity<OnlineVotingApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<OnlineVotingApplicationContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
