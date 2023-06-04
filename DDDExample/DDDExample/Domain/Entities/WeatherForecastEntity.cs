using DDDExample.Domain.ValueObjects.WeatherForecast;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DDDExample.Domain.Entities
{
    /// <summary>
    /// 天気予報エンティティ
    /// </summary>
    public sealed class WeatherForecastEntity
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="weatherForecastDate"></param>
        /// <param name="temptureC"></param>
        /// <param name="temptureF"></param>
        /// <param name="summary"></param>
        public WeatherForecastEntity(
            DateTime weatherForecastDate,
            int temptureC,
            int temptureF,
            string summary)
        {
            WeatherForecastDate = new WeatherForecastDate(weatherForecastDate);
            TemperatureC = new TemperatureC(temptureC);
            TemperatureF = new TemperatureF(temptureF);
            Summary = new Summary(summary);
        }

        /// <summary>
        /// 日付
        /// </summary>
        public WeatherForecastDate WeatherForecastDate { get; }

        /// <summary>
        /// 温度(C)
        /// </summary>
        public TemperatureC TemperatureC { get; }

        /// <summary>
        /// 温度(F)
        /// </summary>
        public TemperatureF TemperatureF { get; }

        /// <summary>
        /// サマリー
        /// </summary>
        public Summary Summary { get; }
    }
}
