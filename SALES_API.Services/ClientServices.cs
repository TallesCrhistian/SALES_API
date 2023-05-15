using AutoMapper;
using SALES_API.Data.WorkUnit.Interfaces;
using SALES_API.Services.Interfaces;
using SALES_API.Shared.DTOs;
using SALES_API.Shared.ModelViews.Client;
using System.Net;

namespace SALES_API.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IWorkUnit _iWorkUnit;
        private readonly IMapper _mapper;
        private readonly IClientBusiness _iClientBusiness;

        public ClientServices(IWorkUnit workUnit, IMapper mapper, IClientBusiness iClientBusiness)
        {
            _iWorkUnit = workUnit;
            _mapper = mapper;
            _iClientBusiness = iClientBusiness;
        }

        public async Task<ServiceResponseDTO<ClientModelView>> Create(ClientCreateModelView clientCreateModelView)
        {
            ServiceResponseDTO<ClientModelView> serviceResponseDTO = new ServiceResponseDTO<ClientModelView>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(clientCreateModelView);

                serviceResponseDTO.GenericData = _iClientBusiness.Create(clientDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);

                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            }

            return serviceResponseDTO;
        }
    }
}
