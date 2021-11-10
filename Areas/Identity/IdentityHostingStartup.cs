using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourHealthNow.Areas.Identity.Data;
using YourHealthNow.Data;

[assembly: HostingStartup(typeof(YourHealthNow.Areas.Identity.IdentityHostingStartup))]
namespace YourHealthNow.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            _ = builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<YourHealthNowContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("YourHealthNowContextConnection")));

                services.AddDefaultIdentity<YourHealthNowUser>(options =>
                {
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                    .AddEntityFrameworkStores<YourHealthNowContext>();
            });
        }
    }
}