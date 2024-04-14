
using AspApplication.Application.Interfaces;
using AspApplication.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AspApplicationApi.Controllers;

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
