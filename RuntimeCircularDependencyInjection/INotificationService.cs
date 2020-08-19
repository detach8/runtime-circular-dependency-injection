using System;

namespace RuntimeCircularDependencyInjection
{
    public interface INotificationService
    {
        void Notify(string message);
    }
}
