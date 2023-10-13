using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicOrganizer.Models;

namespace MusicOrganizer
{
    public class Startup
    {
        // public Startup(IHostingEnvironment env)
        // {
        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(env.ContentRootPath)
        //         .AddJsonFile("appsettings.json");
        //     Configuration = builder.Build();
        // }

        // public IConfigurationRoot Configuration { get; set; }

        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddMvc();

        //     services.AddEntityFrameworkMySql()
        //         .AddDbContext<MusicOrganizerContext>(options => options
        //             .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));

        //     services.AddIdentity<ApplicationUser, IdentityRole>()
        //         .AddEntityFrameworkStores<MusicOrganizerContext>()
        //         .AddDefaultTokenProviders();

        //     services.Configure<IdentityOptions>(options =>
        //     {
        //         options.Password.RequireDigit = false;
        //         options.Password.RequiredLength = 0;
        //         options.Password.RequireLowercase = false;
        //         options.Password.RequireNonAlphanumeric = false;
        //         options.Password.RequireUppercase = false;
        //         options.Password.RequiredUniqueChars = 0;
        //     });
        // }

        // public void Configure(IApplicationBuilder app)
        // {
        //     app.UseStaticFiles();

        //     app.UseDeveloperExceptionPage();

        //     app.UseAuthentication();

        //     app.UseMvc(routes =>
        //     {
        //         routes.MapRoute(
        //             name: "default",
        //             template: "{controller=Home}/{action=Index}/{id?}");
        //     });

        //     app.Run(async(context) =>
        //     {
        //         await context.Response.WriteAsync("Something went wrong!");
        //     });
        // }
    }
    public static class DBConfiguration
    {
      public static string ConnectionString = "server=localhost;user id=root;password=3picodu$4991;port=3306;database=music_organizer;";
    }
}