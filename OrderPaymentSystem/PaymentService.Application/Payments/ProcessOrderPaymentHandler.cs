using PaymentService.Application.Interfaces;
using PaymentService.Application.Events;
using PaymentService.Domain.Entities;


namespace PaymentService.Application.Payments
{
    public class ProcessOrderPaymentHandler
    {
        private readonly IPaymentRepository _repository;

        public ProcessOrderPaymentHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(OrderCreatedEvent message, CancellationToken cancellationToken)
        {
            if (message.Amount <= 0)
                throw new ArgumentException("Invalid payment amount.");

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = message.OrderId,
                Amount = message.Amount,
                CreatedAt = DateTime.UtcNow
            };

            var processed = await _repository.SavePaymentAsync(
                payment,
                message.EventId,
                cancellationToken);

            if (!processed)
            {
                // Event wurde bereits verarbeitet.
                return;
            }
        }
    }
}
