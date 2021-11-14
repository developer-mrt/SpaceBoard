using SpaceBoard.Core.Base.Boards;
using SpaceBoard.Core.Infrastructure;
using SpaceBoard.Core.Validators.Boards;
using SpaceBoard.Core.Validators.Devices;
using SpaceBoard.Services.Common;
using SpaceBoard.Services.Devices.Rovers;
using SpaceBoard.Services.Devices.Rovers.Services;
using SpaceBoard.Services.Initializations;
using Microsoft.Extensions.DependencyInjection;

namespace SpaceBoard.ConsoleApp
{
    public class Startup
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Devices
            services.AddScoped<IRover, Rover>();

            //Boards
            services.AddScoped<IBoard, Board>();

            //Infrastructure
            services.AddScoped<IInvoker, RoverInvoker>();

            //Validators
            services.AddScoped<IDeviceValidator, DeviceValidator>();
            services.AddScoped<IBoardValidator, BoardValidator>();

            //Services
            services.AddScoped<IInitializationService<IRover>, RoverInitializationService>();
            services.AddScoped<IRoverMoveService, RoverMoveService>();
            services.AddScoped<ICommandParserService, CommandParserService>();
        }
    }
}
