using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using SagaMessages;

namespace SagaChildWebApi
{
    public class DocSentHandler : IHandleMessages<DocSent>
    {
        private static ILog log = LogManager.GetLogger<DocSentHandler>();

        public Task Handle(DocSent message, IMessageHandlerContext context)
        {
            log.Info($"Recvd event msg DocSent: {message.TrackingId}");


            // call would be made to the npb webapi here


            return Task.CompletedTask;
            ;
        }
    }
}
