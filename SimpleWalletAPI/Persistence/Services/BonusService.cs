using Application.Common.Interfaces;
using Domain.Enums;
using Persistence.Models;

namespace Persistence.Services
{
    public class BonusService : IBonusService
    {
        public double GetBonuses()
        {
            var currentDateTime = DateTime.UtcNow;
            //var currentDateTime = new DateTime(2023, 08, 24);

            DateTime seasonStart;
            int currentDay = 0;

            switch (currentDateTime.Month)
            {
                case (int)MonthEnum.March:
                case (int)MonthEnum.April:
                case (int)MonthEnum.May:
                    {
                        seasonStart = new DateTime(currentDateTime.Year, 03, 01);

                        currentDay = (int)(currentDateTime - seasonStart).TotalDays + 1;
                        break;
                    }

                case (int)MonthEnum.June:
                case (int)MonthEnum.July:
                case (int)MonthEnum.August:
                    {
                        seasonStart = new DateTime(currentDateTime.Year, 06, 01);

                        currentDay = (int)(currentDateTime - seasonStart).TotalDays + 1;
                        break;
                    }

                case (int)MonthEnum.September:
                case (int)MonthEnum.October:
                case (int)MonthEnum.November:
                    {
                        seasonStart = new DateTime(currentDateTime.Year, 09, 01);

                        currentDay = (int)(currentDateTime - seasonStart).TotalDays + 1;
                        break;
                    }

                case (int)MonthEnum.December:
                case (int)MonthEnum.January:
                case (int)MonthEnum.February:
                    {
                        seasonStart = new DateTime(currentDateTime.Month == 12
                        ? currentDateTime.Year
                        : currentDateTime.Year -1,
                        12,
                        01);

                        currentDay = (int)(currentDateTime - seasonStart).TotalDays + 1;
                        break;
                    }     
            }

            return (double)currentDay;
        }
    }
}
