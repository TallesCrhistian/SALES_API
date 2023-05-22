using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SALES_API.Business.Interfaces;
using SALES_API.Data.Interfaces;
using SALES_API.Entities;
using SALES_API.Shared.DTOs;

namespace SALES_API.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientBusiness(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDTO> Create(ClientDTO clientDTO)
        {
            clientDTO.Create_at = DateTime.Now;

            Client client = _mapper.Map<Client>(clientDTO);

            client = await _clientRepository.Create(client);

            clientDTO = (client is not null) ? _mapper.Map<ClientDTO>(client)
                : throw new HttpRequestException();

            return clientDTO;
        }

        public async Task<ClientDTO> Read(Guid id)
        {
            Client client = await _clientRepository.Read(id);

            ClientDTO clientDTO = client is not null ? _mapper.Map<ClientDTO>(client)
                : throw new HttpRequestException();

            return clientDTO;
        }

        public async Task<ClientDTO> Update(ClientDTO clientDTO)
        {
            Client client = _mapper.Map<Client>(clientDTO);
            client.Update_at = DateTime.Now;
            client = await _clientRepository.Update(client);

            clientDTO = client is not null ? _mapper.Map<ClientDTO>(client)
                : throw new HttpRequestException();

            return clientDTO;
        }

    }
}
