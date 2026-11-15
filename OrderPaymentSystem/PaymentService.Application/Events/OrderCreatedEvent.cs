namespace PaymentService.Application.Events;

public record OrderCreatedEvent(
    Guid EventId,
    Guid OrderId,
    decimal Amount,
    DateTime CreatedAt
);