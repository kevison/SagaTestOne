//=====================================================================
// this endpoint would handle commands
//=====================================================================
using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace SagaChildDsEndpoint
{
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "Ds Endpoint";

            var epCfg = new EndpointConfiguration("DsEndpoint");
            //var transport = epCfg.UseTransport<LearningTransport>();
            var transport = epCfg.UseTransport<MsmqTransport>();

            var epInstance = await Endpoint.Start(epCfg).ConfigureAwait(false);

            Console.WriteLine("DS endpoint created. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
