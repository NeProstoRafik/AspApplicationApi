using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using AspApplicationApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspApplicationApi.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("model")]
        public async Task<ActionResult<ApplicationResponce>> Create(ApplicationDTO model)
        {
            var result = await _applicationService.Create(model);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}/update")]
        public async Task<ActionResult<ApplicationResponce>> Update(Guid id, ApplicationDTOUpdate model)
        {
            var res = await _applicationService.Update(id, model);
            if (res==null)
            {
                return BadRequest();
            }
            return res;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var responce= await _applicationService.Delete(id);
            if (responce==true)
            {
                return Ok();
            }
            return BadRequest();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationResponce>> GetById(Guid id)
        {
            var res = await _applicationService.Get(id);
            if (res is not null)
            {
                return res;
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("{id}/submid")]
        public async Task<IActionResult> Submid(Guid id)
        {
            var res = await _applicationService.UpdateSubmid(id);
            if (res == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("GetAfterDateOrUnsubmittedOlder")]
        public async Task<ActionResult<List<ApplicationResponce>>> GetApplicationsAfterDateOrUnsubmittedOlder(DateTime? submittedAfter, DateTime? unsubmittedOlder )
        {
            if (submittedAfter!= null && unsubmittedOlder != null)
            {
                return BadRequest();
            }
            if (submittedAfter !=null)
            {
                var res = await _applicationService.GetApplicationsAfterDate((DateTime)submittedAfter);
                if (res is not null)
                {
                    return res;
                }
                else
                {
                    return NotFound();
                }
            }

            if (unsubmittedOlder != null)
            {
                var resOlder = await _applicationService.UnsubmittedOlder((DateTime)unsubmittedOlder);
                if (resOlder is not null)
            {
                    return resOlder;
                }
            else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }
                
    }
}
