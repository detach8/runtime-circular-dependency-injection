using System;

namespace RuntimeCircularDependencyInjection
{
    public class PaymentHandlerC : IPaymentHandler
    {
        public IPaymentService PaymentService { get; set; }
        public INotificationService NotificationService { get; set; }

        public PaymentHandlerC(
            IPaymentService paymentService,
            INotificationService notificationService)
        {
            PaymentService = paymentService;
            NotificationService = notificationService;
        }

        public void OnCapture(decimal amount)
        {
            if (amount > 50)
            {
                NotificationService.Notify($"Service C got {amount}");
                PaymentService.Update(amount);
            }
        }
    }
}
