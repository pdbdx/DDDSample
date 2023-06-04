namespace DDDExample.Domain.Repositories.Parameters.WeatherForecast
{
    public class GetByDateRangeParams
    {
        public GetByDateRangeParams(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}
