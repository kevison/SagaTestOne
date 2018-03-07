using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using SagaMessages;

namespace EfWrapperEndpoint
{
    public class DocSentHandler : IHandleMessages<DocSent>
    {
        static ILog log = LogManager.GetLogger<DocSentHandler>();

        public Task Handle(DocSent message, IMessageHandlerContext context)
        {
            log.Info($"EF Wrapper has received doc sent notification {message.LoanId} - {message.TrackingId}");

            // make call to ef to send saga data to table....


            return Task.CompletedTask;
        }
    }
}
