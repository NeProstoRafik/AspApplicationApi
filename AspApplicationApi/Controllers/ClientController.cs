
using AspApplication.Application.Contracts;
using AspApplication.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspApplicationApi.Controllers;

public class ClientController : Controller
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("/client/{id}")]
    
    public async Task<ActionResult<ApplicationResponce>> GetByClient(Guid id)
    {
        var res = await _clientService.GetUnsubmit(id);

        if (res.StatusCode== AspApplication.Domain.Enum.StatusCode.OK)
        {          
            return res.Data;
        }       
            return BadRequest(res.Errors);       
    }
}
