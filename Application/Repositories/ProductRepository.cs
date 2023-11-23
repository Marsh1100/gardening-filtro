using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class ProductRepository : GenericRepository<Product>, IProduct
{
    private readonly GardeningContext _context;

    public ProductRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }


}