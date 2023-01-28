using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                        Configuration.GetConnectionString("OnlineVotingApplicationConnection")));

            services.AddDefaultIdentity<OnlineVotingApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<OnlineVotingApplicationContext>();
        }
    }
}
