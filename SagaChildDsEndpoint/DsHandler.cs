using System;
using NServiceBus;
using NServiceBus.Logging;
using SagaMessages.Nsb;
using Task = System.Threading.Tasks.Task;

namespace SagaChildDsEndpoint
{
    public class DsHandler : IHandleMessages<RequestDsSomething>
    {
        static ILog log = LogManager.GetLogger<DsHandler>();

        public async Task Handle(RequestDsSomething message, IMessageHandlerContext context)
        {
            log.Info($"Recvd Request Ds Somthing {message.TrackId}");

            var nGuid = Guid.NewGuid();
            var msg = new RequestSendDocument
            {
                TrackingId = nGuid,
                LoanNumber = "1000000123",
                Status = "Send"
            };

            await context.Send("EfWrapper", msg).ConfigureAwait(false);

            //return Task.CompletedTask;
        }
    }
}
