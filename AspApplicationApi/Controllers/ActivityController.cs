using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using AspApplicationApi.Service.Emplementations;
using AspApplicationApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspApplicationApi.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("activities")]
    
        public ActionResult<List<TypeActivity>> GetActivity()
        {
          return _activityService.GetAllActivity();
        }
    }
}
