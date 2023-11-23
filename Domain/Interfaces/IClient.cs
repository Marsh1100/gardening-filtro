using Domain.Entities;

namespace Domain.Interfaces;

public interface IClient : IGenericRepository<Client> 
{ 
    Task<IEnumerable<object>> GetClientsWithPaymentsAndSeller();
    Task<IEnumerable<Client>> GetClientsWithoutPayments();
    Task<IEnumerable<object>> GetClientsWithSellerAndOffice();

    Task<IEnumerable<object>> GetClientsWithoutPaymentsWithSellerAndOffice();

}