using NServiceBus;

namespace SagaMessages
{
    public class SendDocumentCmd : ICommand
    {
        public string TrackingId { get; set; }
        public string LoanId { get; set; }
        public string Status { get; set; }
    }
}
