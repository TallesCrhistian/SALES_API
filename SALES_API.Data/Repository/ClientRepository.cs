using Microsoft.EntityFrameworkCore;
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

        public async Task<Client> Read(Guid id)
        {
            Client client = await _appDbContext.Clients.Where(x => x.Id == id) 
                .FirstOrDefaultAsync();

             await _appDbContext.SaveChangesAsync();

            return client;
        }

        public async Task<Client> Update(Client client)
        {
            Client existingClient = await _appDbContext.Clients.Where(x => x.Id == client.Id)
                .FirstOrDefaultAsync();

            if (existingClient != null)
            {
                _appDbContext.Entry(existingClient).CurrentValues.SetValues(client);
                await _appDbContext.SaveChangesAsync();
                return client;
            }

            return existingClient;
        }
        
    }
}
