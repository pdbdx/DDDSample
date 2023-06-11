using DDDExample.Controllers.DTO;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Repositories;
using DDDExample.Domain.Repositories.Parameters.WeatherForecast;
using DDDExample.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DDDExample.Controllers
{
    [ApiController]
    [Route("api/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastRepository _weatherForecast;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WeatherForecastController(): this(Factories.CreateWeatherForecast()){ }

        private WeatherForecastController(IWeatherForecastRepository weatherForecast)
        {
            _weatherForecast = weatherForecast;
        }

        [HttpGet("latest", Name = "latest")]
        public Task<WeatherForecastEntity> GetLatest()
        {
            return _weatherForecast.GetLatest();
        }

        [HttpGet("daterange", Name = "daterange")]
        public Task<IReadOnlyList<WeatherForecastEntity>> GetWeatherForecastByDateRange(DateTime startDate, DateTime endDate)
        {
            var parameters = new GetByDateRangeParams(startDate, endDate);
            return _weatherForecast.GetByDateRange(parameters);
        }

        [HttpPost]
        public IActionResult Post(WeatherForecastDTO dto)
        {
            // TransactionScopeを使用してトランザクションを開始する
            using (var scope = new TransactionScope()) {

                var entity = new WeatherForecastEntity
                    (
                        dto.WeatherForecastDate,
                        dto.TemperatureC,
                        dto.TemperatureF,
                        dto.Summary ?? string.Empty
                    );
                _weatherForecast.Save(entity);
                
                // コミット
                scope.Complete();
                return Ok();
            }
        }
    }
}