using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using OnlineVotingApplication.Areas.Identity.Data;
using OnlineVotingApplication.Data;
using OnlineVotingApplication.Models;
using System.Security.Cryptography.X509Certificates;

namespace OnlineVotingApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<OnlineVotingApplicationContext>();
                    var userManager = services.GetRequiredService<UserManager<OnlineVotingApplicationUser>>();

                    DbInitializer.InitializeAsync(context, services, userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}