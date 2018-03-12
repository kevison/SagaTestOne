using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using SagaMessages.Nsb;

namespace EfWrapperEndpoint
{
    public class DocSentHandler : IHandleMessages<RequestSendDocument>
    {
        static ILog log = LogManager.GetLogger<DocSentHandler>();

        public async Task Handle(RequestSendDocument message, IMessageHandlerContext context)
        {
            log.Info($"Received RequestSendDocument notification {message.LoanNumber} - {message.Status}");

            var resp = new SendDocumentResponse
            {
                TrackingId = message.TrackingId,
                LoanNumber = message.LoanNumber,
                Status = "Sent"
            };

            var reqst = new RequestDsSomething
            {
                TrackId = message.TrackingId,
                EnvelopeId = Guid.NewGuid(),
                Status = message.Status
            };

            //await context.Send("DsEndpoint", reqst).ConfigureAwait(false);

            log.Info($"Received RequestSendDocument notification {message.LoanNumber} - {message.Status} - update db with status");

            //return Task.CompletedTask;
        }
    }
}
