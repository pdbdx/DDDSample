using DDDExample.Domain.Entities;
using DDDExample.Domain.Repositories;
using DDDExample.Domain.Repositories.Parameters.WeatherForecast;

namespace DDDExample.Infrastructure.DataAccess.Dummy
{
    public class WeatherForecastDummy : IWeatherForecastRepository
    {
        public WeatherForecastEntity GetLatest()
        {
            return new WeatherForecastEntity
                (
                    Convert.ToDateTime("2023-06-01"),
                    20,
                    30,
                    "Cool"
                );
        }

        public IReadOnlyList<WeatherForecastEntity> GetByDateRange(GetByDateRangeParams parameters)
        {
            return new List<WeatherForecastEntity>
            {
                new WeatherForecastEntity(Convert.ToDateTime("2023-05-31"), 20, 30, "Cool"),
                new WeatherForecastEntity(Convert.ToDateTime("2023-06-01"), 21, 31, "Cool"),
                new WeatherForecastEntity(Convert.ToDateTime("2023-06-02"), 22, 32, "Cool"),
                new WeatherForecastEntity(Convert.ToDateTime("2023-06-03"), 23, 33, "Cool")
            };
        }

        public void Save(WeatherForecastEntity weather)
        {
            
        }
    }
}
