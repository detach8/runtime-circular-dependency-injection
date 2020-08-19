using System;

namespace RuntimeCircularDependencyInjection
{
    public class PaymentHandlerB : IPaymentHandler
    {
        public IPaymentService PaymentService { get; set; }
        public INotificationService NotificationService { get; set; }

        public PaymentHandlerB(
            IPaymentService paymentService,
            INotificationService notificationService)
        {
            PaymentService = paymentService;
            NotificationService = notificationService;
        }

        public void OnCapture(decimal amount)
        {
            if (amount > 10)
            {
                NotificationService.Notify($"Service B got {amount}");
                PaymentService.Update(amount);
            }
        }
    }
}
