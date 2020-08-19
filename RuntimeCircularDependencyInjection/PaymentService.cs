using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace RuntimeCircularDependencyInjection
{
    public class PaymentService : IPaymentService
    {
        public IServiceProvider ServiceProvider { get; set; }
        public INotificationService NotificationService { get; set; }

        public PaymentService(
            IServiceProvider serviceProvider,
            INotificationService notificationService)
        {
            ServiceProvider = serviceProvider;
            NotificationService = notificationService;
        }

        public void Capture(decimal amount)
        {
            NotificationService.Notify($"PaymentService captured {amount}");

            foreach (var paymentHandler in ServiceProvider.GetServices<IPaymentHandler>())
            {
                paymentHandler.OnCapture(amount);
            }
        }

        public void Update(decimal amount)
        {
            NotificationService.Notify($"PaymentService updated {amount}");
        }
    }
}
