using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using SagaMessages;

namespace SagaChildDsEndpoint
{
    public class SendDocumentCmdHandler : 
        IHandleMessages<SendDocumentCmd>
    {
        private static ILog log = LogManager.GetLogger<SendDocumentCmdHandler>();

        public Task Handle(SendDocumentCmd message, IMessageHandlerContext context)
        {
            log.Info($"Command recieved: {message.TrackingId} - {message.LoanId}");

            //
            //  next send an event to the webapi endpoint - send 
            //  business logic here .... 
            //  ... send something to EF wrapper to update saga table in db
            var docSent = new DocSent
            {
                TrackingId = message.TrackingId,
                LoanId = message.LoanId,
                Status = message.Status
            };

            return context.Publish(docSent);
        }
    }
}
