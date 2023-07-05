using AutoMapper;
using SALES_API.Business.Interfaces;
using SALES_API.Data.WorkUnit.Interfaces;
using SALES_API.Services.Interfaces;
using SALES_API.Shared.DTOs;
using SALES_API.Shared.Messages;
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

        public async Task<ServiceResponseDTO<ClientViewModel>> Create(ClientCreateViewModel clientCreateModelView)
        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = new ServiceResponseDTO<ClientViewModel>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(clientCreateModelView);
                clientDTO = await _iClientBusiness.Create(clientDTO);

                serviceResponseDTO.GenericData = _mapper.Map<ClientViewModel>(clientDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
                serviceResponseDTO.Message = OkMessages.ClientCreated;
                serviceResponseDTO.Sucess = true;

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

        public async Task<ServiceResponseDTO<ClientViewModel>> Read(Guid id)
        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = new ServiceResponseDTO<ClientViewModel>();

            try
            {
                ClientDTO clientDTO = await _iClientBusiness.Read(id);

                serviceResponseDTO.GenericData = _mapper.Map<ClientViewModel>(clientDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.ClientRead;
                serviceResponseDTO.Sucess = true;

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

        public async Task<ServiceResponseDTO<ClientViewModel>> Update(ClientUpdateViewModel clientUpdateViewModel)
        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = new ServiceResponseDTO<ClientViewModel>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(clientUpdateViewModel);
                clientDTO = await _iClientBusiness.Update(clientDTO);

                serviceResponseDTO.GenericData = _mapper.Map<ClientViewModel>(clientDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.ClientRead;
                serviceResponseDTO.Sucess = true;

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

        public async Task<ServiceResponseDTO<ClientViewModel>> Delete(Guid id)
        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = new ServiceResponseDTO<ClientViewModel>();

            try
            {
                ClientDTO clientDTO = await _iClientBusiness.Delete(id);

                serviceResponseDTO.GenericData = _mapper.Map<ClientViewModel>(clientDTO);
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                serviceResponseDTO.Message = OkMessages.ClientDeleted;
                serviceResponseDTO.Sucess = true;

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
