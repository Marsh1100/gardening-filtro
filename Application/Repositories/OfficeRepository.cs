using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class OfficeRepository : GenericRepository<Office>, IOffice
{
    private readonly GardeningContext _context;

    public OfficeRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }


}