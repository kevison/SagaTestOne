//=================================================================================
// ef wrapper endpoint... subscribes to docsent, docrecvd, etc....
// 
// from the handlers... update table accordingly.
//=================================================================================
using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

namespace EfWrapperEndpoint
{
    class Program
    {
        private static ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "EF Wrapper";

            var epCfg = new EndpointConfiguration("EfWrapper");
            //epCfg.UseTransport<LearningTransport>();
            epCfg.UseTransport<MsmqTransport>();

            var endpointInstance = await Endpoint.Start(epCfg).ConfigureAwait(false);

            Console.WriteLine("EF Wrapper endpoint created. Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
