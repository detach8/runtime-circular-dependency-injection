using System;

namespace RuntimeCircularDependencyInjection
{
    public class PaymentHandlerA : IPaymentHandler
    {
        public IPaymentService PaymentService { get; set; }
        public INotificationService NotificationService { get; set; }

        public PaymentHandlerA(
            IPaymentService paymentService,
            INotificationService notificationService)
        {
            PaymentService = paymentService;
            NotificationService = notificationService;
        }

        public void OnCapture(decimal amount)
        {
            if (amount > 0)
            {
                NotificationService.Notify($"Service A got {amount}");
                PaymentService.Update(amount);
            }
        }
    }
}
