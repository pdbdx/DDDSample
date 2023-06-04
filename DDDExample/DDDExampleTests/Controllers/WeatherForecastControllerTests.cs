using DDDExample.Controllers.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDExample.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        [TestMethod()]
        public void GetLatestTest()
        {
            var weatherForecastController = new WeatherForecastController();
            var response = weatherForecastController.GetLatest();
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void GetWeatherForecastByDateRangeTest()
        {
            var weatherForecastController = new WeatherForecastController();
            var startDate = Convert.ToDateTime("2023-05-27");
            var endDate = Convert.ToDateTime("2023-05-28");
            var response = weatherForecastController.GetWeatherForecastByDateRange(startDate, endDate);
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void PostTest()
        {
            var dto = new WeatherForecastDTO() 
            {
                WeatherForecastDate = Convert.ToDateTime("2023-06-01"),
                TemperatureC = 20,
                TemperatureF = 30,
                Summary = "Cool"
            };
            
            var weatherForecastController = new WeatherForecastController();

            var response = weatherForecastController.Post(dto);
            Assert.IsNotNull(response);
        }
    }
}