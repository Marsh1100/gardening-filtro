using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class ProducttypeRepository : GenericRepository<Producttype>, IProducttype
{
    private readonly GardeningContext _context;

    public ProducttypeRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }


}