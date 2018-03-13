//================================================================================
// This is the actual saga
//
//
//
//
//================================================================================
using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using SagaMessages;
using SagaMessages.Nsb;

namespace SagaTestOne
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger<Program>();

        static async Task Main(string[] args)
        {
            Console.Title = "Saga UI start point";

            var epConfiguration = new EndpointConfiguration("SagaUI");

            // setup to send to another endpoint
            var transport = epConfiguration.UseTransport<LearningTransport>();

            // map message routing
            //var routing = transport.Routing();
            //routing.RouteToEndpoint(typeof(RequestDsSomething), "DsEndpoint");
            //routing.RouteToEndpoint(typeof(RequestSendDocument), "EfWrapper");

            var endpointInstance = await Endpoint.Start(epConfiguration).ConfigureAwait(false);

            await RunLoop2(endpointInstance).ConfigureAwait(false);

            await endpointInstance.Stop().ConfigureAwait(false);
        }

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            Console.Clear();

            while (true)
            {
                log.Info("Press 'P' to place an order, or 'Q' to quit.");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var cmd = new SendDocumentCmd
                        {
                            TrackingId = Guid.NewGuid().ToString(),
                            LoanId = "1000000548",
                            Status = "Send"
                        };
                        log.Info($"Sending SEND DOCUMENT command: {cmd.TrackingId}");
                        await endpointInstance.Send(cmd).ConfigureAwait(true);

                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        log.Info("Unknown input, please try again.");
                        break;
                }
            }

        }

        static async Task RunLoop2(IEndpointInstance endpointInstance)
        {
            Console.Clear();

            while (true)
            {
                log.Info("Press 'enter' to publish, or 'Q' to quit.");

                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }

                var nGuid = Guid.NewGuid();
                Console.WriteLine($"Request by id: {nGuid}");

                var msg = new RequestDsSomething()
                {
                    TrackId = nGuid,
                    Status = "Send"
                };

                await endpointInstance.Send("DsEndpoint", msg).ConfigureAwait(false);

            }

        }
    }
}
