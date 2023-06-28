using Domain.Enums;

namespace Persistence.Models
{
    public class Season
    {
        public DateOnly SeasonStart { get; set; }
        public List<MonthEnum> Months { get; set; }
    }
}
