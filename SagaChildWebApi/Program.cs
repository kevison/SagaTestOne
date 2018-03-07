//=====================================================================
// this endpoint would handle events 
//=====================================================================
using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace SagaChildWebApi
{
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "Wapi Endpoint";

            var epCfg = new EndpointConfiguration("WapiEndpoint");   // event subscriber
            var transport = epCfg.UseTransport<LearningTransport>();

            var epInstance = await Endpoint.Start(epCfg).ConfigureAwait(false);

            Console.WriteLine("WebApi endpoing created. Press Enter to exit.");
            Console.ReadLine();

            await epInstance.Stop().ConfigureAwait(false);
        }
    }
}
