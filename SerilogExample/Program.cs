using System;
using Serilog;

namespace SerilogExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Log
            Log.Logger = new LoggerConfiguration()
                .Enrich.With<UserEnricher>()
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{UserId}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs\\logFile.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:HH:mm:ss} [{UserId}] {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            User user = new User(1, "Gabriel", DateTime.Now);

            Log.Information("Hello, world!");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }

            Log.CloseAndFlush();
            Console.ReadKey();
            #endregion
        }
    }
}
