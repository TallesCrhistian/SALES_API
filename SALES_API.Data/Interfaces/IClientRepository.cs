using SALES_API.Entities;

namespace SALES_API.Data.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> Create(Client client);
    }
}