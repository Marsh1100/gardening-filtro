using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class PaymentRepository : GenericRepository<Payment>, IPayment
{
    private readonly GardeningContext _context;

    public PaymentRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByPaypal2008()
    {
        return   await _context.Payments
                .Where(d=> d.PaymentMethod == "Paypal" && d.PaymentDate.Year.Equals(2008))
                .OrderByDescending(o=> o.Total)
                .ToListAsync();
    }
}