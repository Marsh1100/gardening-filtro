using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class RequestRepository : GenericRepository<Request>, IRequest
{
    private readonly GardeningContext _context;

    public RequestRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }


}