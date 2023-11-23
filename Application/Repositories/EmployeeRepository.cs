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

    //4
    public async Task<IEnumerable<object>> GetBossAndSuperBoss()
    {
        var employees = await _context.Employees.ToListAsync();

        return      from emp in employees 
                    join boss in employees on emp.IdBoss equals boss.Id into h
                    from  allBoss in h.DefaultIfEmpty()
                    join superBoss in employees on allBoss.IdBoss equals superBoss.Id into h2
                    from allSuperBoss in h2.DefaultIfEmpty()
                    select new 
                    {
                        employee = emp.Name,
                        boss = allBoss?.Name,
                        superBoss = allSuperBoss?.Name
                    };
    }
}