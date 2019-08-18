using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace ProFinder.WebAPI
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = 
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                      .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                                      .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration)
                                                  .CreateLogger();
            try
            {
                Log.Information("Initializing application...");
                CreateWebHostBuilder(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                       .UseStartup<Startup>()
                       .UseConfiguration(Configuration)
                       .UseSerilog()
                       .Build();
    }
}
