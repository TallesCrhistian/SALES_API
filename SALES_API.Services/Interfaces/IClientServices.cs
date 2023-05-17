using SALES_API.Shared.DTOs;
using SALES_API.Shared.ModelViews.Client;

namespace SALES_API.Services.Interfaces
{
    public interface IClientServices
    {
        Task<ServiceResponseDTO<ClientViewModel>> Create(ClientCreateViewModel clientCreateModelView);
    }
}