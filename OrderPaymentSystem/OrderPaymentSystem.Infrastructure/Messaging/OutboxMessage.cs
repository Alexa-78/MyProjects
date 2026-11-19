using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPaymentSystem.Infrastructure.Messaging
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }

        public string EventType { get; set; } = string.Empty;

        public string Payload { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime? ProcessedAt { get; set; }

        public string? Error { get; set; }
    }
}
