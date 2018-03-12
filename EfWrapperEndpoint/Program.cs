//=================================================================================
// ef wrapper endpoint... 
// from the handlers... update table accordingly.
//=================================================================================
using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace EfWrapperEndpoint
{
     /*********************************************************
     * Subscriber endpoint
    **********************************************************/
    class Program
    {
        private static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "EF Wrapper";

            var epCfg = new EndpointConfiguration("EfWrapper");
            epCfg.UseTransport<LearningTransport>();
            epCfg.UsePersistence<LearningPersistence>();

            var endpointInstance = await Endpoint.Start(epCfg).ConfigureAwait(false);

            Console.WriteLine("EF Wrapper endpoint created. Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
