using Microsoft.AspNetCore.Mvc;
using SALES_API.Services.Interfaces;
using SALES_API.Shared.DTOs;
using SALES_API.Shared.ModelViews.Client;

namespace SALES_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _iClientServices;

        public ClientController(IClientServices clientServices)
        {
            _iClientServices = clientServices;
        }
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientCreateViewModel clientCreateModelView)

        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = await _iClientServices.Create(clientCreateModelView);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Read(Guid id)

        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = await _iClientServices.Read(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientUpdateViewModel clientUpdateViewModel)

        {
            ServiceResponseDTO<ClientViewModel> serviceResponseDTO = await _iClientServices.Update(clientUpdateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }
    }
}
