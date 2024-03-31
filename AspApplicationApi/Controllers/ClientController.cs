using AspApplicationApi.Domain.ViewModel;
using AspApplicationApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspApplicationApi.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}/client")]
        public async Task<ActionResult<ApplicationResponce>> GetByClient(Guid id)
        {
            var res = await _clientService.GetUnSubmit(id);
            if (res is not null)
            {
                return res;
            }
            else
            {
                return NotFound();
            }

        }
    }
}
