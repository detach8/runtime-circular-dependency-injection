using System;

namespace RuntimeCircularDependencyInjection
{
    public interface IPaymentHandler
    {
        void OnCapture(decimal amount);
    }
}
