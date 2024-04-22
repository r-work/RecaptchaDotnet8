using GoogleCaptchaComponent;
using GoogleCaptchaComponent.Configuration;
using GoogleCaptchaComponent.Models;
using RecaptchaDotnet8.Components;

namespace RecaptchaDotnet8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents();

            builder.Services.AddGoogleCaptcha(options =>
            {
                options.DefaultVersion = CaptchaConfiguration.Version.V2;
                options.V3SiteKey = "Your V3 Site key from Google developer Console";
                options.V2SiteKey = "Your V2 site key from Google developer Console";
                options.DefaultTheme = CaptchaConfiguration.Theme.Dark;
                options.DefaultLanguage = CaptchaLanguages.English;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>();

            app.Run();
        }
    }
}
