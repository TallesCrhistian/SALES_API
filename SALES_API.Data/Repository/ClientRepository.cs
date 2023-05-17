using SALES_API.Data.Interfaces;
using SALES_API.Entities;

namespace SALES_API.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Client> Create(Client client)
        {
            await _appDbContext.Set<Client>().AddAsync(client);
            await _appDbContext.SaveChangesAsync();

            return client;
        }
    }
}
