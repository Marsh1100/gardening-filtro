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


}