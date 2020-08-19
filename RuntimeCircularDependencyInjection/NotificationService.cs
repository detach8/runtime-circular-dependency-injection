using System;

namespace RuntimeCircularDependencyInjection
{
    public class NotificationService : INotificationService
    {
        public NotificationService()
        {
        }

        public void Notify(string message)
        {
            Console.WriteLine($"NOTIFICATION: {message}");
        }
    }
}
