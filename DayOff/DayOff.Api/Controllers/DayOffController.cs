using DayOff.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DayOff.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffController : ControllerBase
    {
        private readonly IDayOffRequestService dayOffRequestService;

        public DayOffController(IDayOffRequestService dayOffRequestService)
        {
            this.dayOffRequestService = dayOffRequestService;
        }

        [HttpPost]
        public IActionResult RequestDayOff(DateTime from, DateTime to)
        {
            var result = dayOffRequestService.RequestDayOff(from, to);

            return result.Match<IActionResult>(
                Succ: _ => Ok(),
                Fail: ex => BadRequest(ex.Message)
            );
        }
    }
}
