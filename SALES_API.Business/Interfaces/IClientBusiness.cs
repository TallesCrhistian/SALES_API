using SALES_API.Shared.DTOs;

namespace SALES_API.Business.Interfaces
{
    public interface IClientBusiness
    {
        Task<ClientDTO> Create(ClientDTO clientDTO);

        Task<ClientDTO> Read(Guid id);

        Task<ClientDTO> Update(ClientDTO clientDTO);
    }
}