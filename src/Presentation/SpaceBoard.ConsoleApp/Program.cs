using SpaceBoard.Core.Infrastructure;
using SpaceBoard.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;

namespace SpaceBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            IFileProvider fileProvider = new FileProvider();
            string directoryPath = AppSettingsDefaults.DirectoryPath;

            var settingsFile = fileProvider.GetFiles(directoryPath, "*.txt").FirstOrDefault();
            if (settingsFile == null)
            {
                throw new ApplicationException($"Could not find any settings file");
            }

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var commandGenerator = serviceProvider.GetService<ICommandParserService>();
            var invoker = serviceProvider.GetService<IInvoker>();

            var file = fileProvider.ReadAllText(settingsFile, Encoding.UTF8);

            var commands = commandGenerator.Parse(file, 1);
            invoker.SetCommands(commands);
            invoker.InvokeCommands();

            var result = invoker.GetResult();


            Console.WriteLine(result);


            commands = commandGenerator.Parse(file, 3);
            invoker.SetCommands(commands);
            invoker.InvokeCommands();

            result = invoker.GetResult();

            Console.WriteLine(result);

            Console.ReadKey();

        }
    }
}
