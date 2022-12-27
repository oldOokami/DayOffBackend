using LanguageExt;
using LanguageExt.Common;

namespace DayOff.Api.Services
{
    public interface IDayOffRequestService
    {
        Result<Unit> RequestDayOff(DateTime from, DateTime to);
    }
}
