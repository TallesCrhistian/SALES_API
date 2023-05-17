using SALES_API.Shared.DTOs;

namespace SALES_API.Business.Interfaces
{
    public interface IClientBusiness
    {
        Task<ClientDTO> Create(ClientDTO clientDTO);
    }
}