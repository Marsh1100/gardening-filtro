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

    public async Task<IEnumerable<object>> GetWithoutRequest()
    {

        var products = await _context.Products.ToListAsync();
        var producttypes  = await _context.Producttypes.ToListAsync();
        var requestdetails = await _context.Requestdetails.ToListAsync();

       return (from product in  products
                join requestdetail in requestdetails on product.Id equals requestdetail.IdProduct into h
                join producttype in producttypes on product.IdProductType equals producttype.Id
                from all in h.DefaultIfEmpty()
                where all?.Id == null
                select new {
                    product_name = product.Name,
                    description = product.Description,
                    image = producttype.Image
                }).Distinct();
                            
    }
}