using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class EmployeeRepository : GenericRepository<Employee>, IEmployee
{
    private readonly GardeningContext _context;

    public EmployeeRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }


}