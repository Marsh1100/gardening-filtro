using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class ClientRepository : GenericRepository<Client>, IClient
{
    private readonly GardeningContext _context;

    public ClientRepository(GardeningContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetClientsWithPaymentsAndSeller()
    {
        return await (from client in _context.Clients
                        join payment in _context.Payments on client.Id equals payment.IdClient
                        join employee in _context.Employees on client.IdEmployee equals employee.Id
                        join office in _context.Offices on employee.IdOffice equals office.Id   
                        select new {
                            name_client = client.NameClient,
                            employee = new {
                                    name = employee.Name + employee.FirstSurname,
                                    city_of_office = office.City
                            }
                        }
                    )
                    .Distinct()
                    .ToListAsync();
    }

    public async Task<IEnumerable<Client>> GetClientsWithoutPayments()
    {
        var clients = await _context.Clients.ToListAsync();
        return  (from client in clients
                        join payment in _context.Payments on client.Id equals payment.IdClient into h
                        from all in h.DefaultIfEmpty()
                        where all?.Id == null
                        select client
                ).Distinct();
    }


    public async Task<IEnumerable<object>> GetClientsWithSellerAndOffice()
    {
        return await (from client in _context.Clients
                        join employee in _context.Employees on client.IdEmployee equals employee.Id
                        join office in _context.Offices on employee.IdOffice equals office.Id   
                        select new {
                            name_client = client.NameClient,
                            employee = new {
                                    name = employee.Name + employee.FirstSurname,
                                    city_of_office = office.City
                            }
                        }
                    )
                    .ToListAsync();
    }
}