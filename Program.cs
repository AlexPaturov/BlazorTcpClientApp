using BlazorTcpClientApp.Services;
using Microsoft.Extensions.Logging;

namespace BlazorTcpClientApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            //--------------------------------------------
            // Registers the local storage services for persisting data on the client side.
            //builder.Services.AddBlazoredLocalStorage();

            // Registers UserService with a Scoped lifetime, meaning a new instance is created per client connection.
            builder.Services.AddSingleton<XmlDecodeService>();  // служба хмл - декодер
            builder.Services.AddSingleton<UserService>();       // служба служит обработчиком и хранилищем информации о пользователе
            builder.Services.AddSingleton<TcpClientService>();  // служба получающая имя пк юзера по TCP от службы windows
            builder.Services.AddSingleton<CommandService>();    // 


            //builder.Services.AddSingleton<UserServiceTwo>();
            // Registers TcpClientService as a Singleton since it manages a persistent TCP connection shared across the application.
            // Registers CommandService as a Hosted Service that runs in the background.
            //--------------------------------------------

            // Configure Logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole(); // Add other logging providers as needed
            var app = builder.Build();
            app.UseExceptionHandler("/Error");
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}