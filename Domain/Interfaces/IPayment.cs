using Domain.Entities;

namespace Domain.Interfaces;

public interface IPayment : IGenericRepository<Payment> 
{ 
    Task<IEnumerable<Payment>> GetPaymentsByPaypal2008();
    Task<IEnumerable<object>> GetMethodsPayments();
}