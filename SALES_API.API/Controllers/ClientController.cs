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
        public async Task<IActionResult> Create([FromBody] ClientCreateModelView clientCreateModelView)

        {
            ServiceResponseDTO<ClientModelView> serviceResponseDTO = await _iClientServices.Create(clientCreateModelView);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }
    }
}
