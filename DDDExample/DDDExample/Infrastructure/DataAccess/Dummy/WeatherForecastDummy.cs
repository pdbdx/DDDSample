using DDDExample.Domain.Entities;
using DDDExample.Domain.Repositories;
using DDDExample.Domain.Repositories.Parameters.WeatherForecast;
using DDDExample.Infrastructure.Extentions;

namespace DDDExample.Infrastructure.DataAccess.Dummy
{
    public class WeatherForecastDummy : IWeatherForecastRepository
    {
        public Task<WeatherForecastEntity> GetLatest()
        {
            return new WeatherForecastEntity(
                Convert.ToDateTime("2023-06-01"),
                20,
                30,
                "Cool"
            ).ToTask();
        }

        public Task<IReadOnlyList<WeatherForecastEntity>> GetByDateRange(GetByDateRangeParams parameters)
        {
            IReadOnlyList<WeatherForecastEntity> weatherForecastEntityList = new List<WeatherForecastEntity>
                {
                    new WeatherForecastEntity(Convert.ToDateTime("2023-05-31"), 20, 30, "Cool"),
                    new WeatherForecastEntity(Convert.ToDateTime("2023-06-01"), 21, 31, "Cool"),
                    new WeatherForecastEntity(Convert.ToDateTime("2023-06-02"), 22, 32, "Cool"),
                    new WeatherForecastEntity(Convert.ToDateTime("2023-06-03"), 23, 33, "Cool")
                };
            return weatherForecastEntityList.ToTask();
        }

        public Task Save(WeatherForecastEntity weather)
        {
            return Task.CompletedTask;
        }
    }
}
