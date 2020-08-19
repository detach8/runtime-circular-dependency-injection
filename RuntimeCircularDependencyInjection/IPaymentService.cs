using System;

namespace RuntimeCircularDependencyInjection
{
    public interface IPaymentService
    {
        void Capture(decimal amount);
        void Update(decimal amount);
    }
}
