//=====================================================================
// ds endpoint
// this endpoint would handle commands?? or published messages
//=====================================================================
using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace SagaChildDsEndpoint
{
    /*********************************************************
     * Subscriber endpoint
    **********************************************************/
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "Ds Endpoint";

            var epCfg = new EndpointConfiguration("DsEndpoint");
            var transport = epCfg.UseTransport<LearningTransport>();
            epCfg.UsePersistence<LearningPersistence>();

            var epInstance = await Endpoint.Start(epCfg).ConfigureAwait(false);

            Console.WriteLine("DS endpoint created. Press Enter to exit.");
            Console.ReadLine();

            await epInstance.Stop().ConfigureAwait(false);
        }
    }
}
