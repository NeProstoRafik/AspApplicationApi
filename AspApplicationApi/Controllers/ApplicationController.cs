using AspApplication.Application.BaseResponse;
using AspApplication.Application.Contracts;
using AspApplication.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspApplicationApi.Controllers;

public class ApplicationController : Controller
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ApplicationResponce>> Create([FromBody] ApplicationDTO model)
    {
        var result = await _applicationService.Create(model);
        return HandleResponse(result);
    }

    [HttpPut("/update/{id}")]
    public async Task<ActionResult<ApplicationResponce>> Update(Guid id, [FromBody] ApplicationDTOUpdate model)
    {
        var result = await _applicationService.Update(id, model);
        return HandleResponse(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _applicationService.Delete(id);
        return HandleResponseWithOutBody(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationResponce>> GetById(Guid id)
    {
        var result = await _applicationService.Get(id);
        return HandleResponse(result);
    }

    [HttpPost("/submit/{id}")]
    public async Task<IActionResult> Submit(Guid id)
    {
        var result = await _applicationService.UpdateSubmit(id);
        return HandleResponseWithOutBody(result);
    }

    [HttpGet("get-after-date-or-unsubmitted-older")]
    public async Task<ActionResult<List<ApplicationResponce>>> GetApplicationsAfterDateOrUnsubmittedOlder([FromQuery] DateTime? submittedAfter, [FromQuery] DateTime? unsubmittedOlder)
    {
        if (submittedAfter != null && unsubmittedOlder != null)
        {
            return BadRequest("не заполняйте оба параметра");
        }

        if (submittedAfter != null)
        {
            var result = await _applicationService.GetApplicationsAfterDate((DateTime)submittedAfter);
            return HandleResponseList(result);
        }
        else if (unsubmittedOlder != null)
        {
            var resOlder = await _applicationService.UnsubmittedOlder((DateTime)unsubmittedOlder);
            return HandleResponseList(resOlder);
        }
        else
        {
            return BadRequest("Invalid parameters");
        }
    }

    private ActionResult<List<ApplicationResponce>> HandleResponseList(Response<List<ApplicationResponce>> response)
    {
        return response.StatusCode == AspApplication.Domain.Enum.StatusCode.OK ? Ok(response.Data) : BadRequest(response.Errors);
    }

    private ActionResult<ApplicationResponce> HandleResponse(Response<ApplicationResponce> response)
    {
        return response.StatusCode == AspApplication.Domain.Enum.StatusCode.OK ? Ok(response.Data) : BadRequest(response.Errors);
    }

    private ActionResult HandleResponseWithOutBody(Response response)
    {
        return response.StatusCode == AspApplication.Domain.Enum.StatusCode.OK ? Ok() : BadRequest(response.Errors);
    }
}
