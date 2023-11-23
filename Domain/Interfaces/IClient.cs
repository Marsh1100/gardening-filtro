using Domain.Entities;

namespace Domain.Interfaces;

public interface IClient : IGenericRepository<Client> 
{ 
    Task<IEnumerable<object>> GetClientsWithPaymentsAndSeller();

}