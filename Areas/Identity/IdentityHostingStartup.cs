using System;
using Daily_Expenses_Final.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Daily_Expenses_Final.Areas.Identity.IdentityHostingStartup))]
namespace Daily_Expenses_Final.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Daily_Expenses_IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Daily_Expenses_IdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Daily_Expenses_IdentityContext>();
            });
        }
    }
}