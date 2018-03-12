using System;
using NServiceBus;

namespace SagaMessages.Nsb
{
    public class DsSomethingResponse : IMessage
    {
        public Guid TrackId { get; set; }
        public Guid EnvelopeId { get; set; }
        public string Status { get; set; }
    }
}
