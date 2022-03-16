using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
// See https://aka.ms/new-console-template for more information
namespace AirlineSendAent{
    class Program{
        static void Main(string[] args)
        {
            var builder= new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(typeof(Program).Assembly, optional:true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);
        }
    }
}