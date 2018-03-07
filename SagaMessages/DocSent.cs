using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace SagaMessages
{
    public class DocSent : IEvent
    {
        public string TrackingId { get; set; }
        public string LoanId { get; set; }
        public string Status { get; set; }
    }
}
