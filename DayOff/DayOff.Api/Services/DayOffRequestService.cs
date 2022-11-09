using DayOff.Api.Exceptions;
using LanguageExt;
using LanguageExt.Common;

namespace DayOff.Api.Services
{
    public class DayOffRequestService : IDayOffRequestService
    {
        public Result<Unit> RequestDayOff(DateTime from, DateTime to)
        {
            if (from > to)
            {
                return new Result<Unit>(new DateDimeRangeValidationException("End of dayOff can't be earlier than start"));
            }

            return Unit.Default;
        }
    }
}
