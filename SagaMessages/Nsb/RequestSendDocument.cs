﻿using System;
using NServiceBus;

namespace SagaMessages.Nsb
{
    public class RequestSendDocument : IMessage
    {
        public Guid TrackingId { get; set; }
        public string LoanNumber { get; set; }
        public string Status { get; set; }
    }
}
