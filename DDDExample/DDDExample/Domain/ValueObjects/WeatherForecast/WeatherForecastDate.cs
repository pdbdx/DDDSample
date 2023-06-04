using DDD.Domain.ValueObjects;

namespace DDDExample.Domain.ValueObjects.WeatherForecast
{
    /// <summary>
    /// エリアID
    /// </summary>
    public sealed class WeatherForecastDate : ValueObject<WeatherForecastDate>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public WeatherForecastDate(DateTime value)
        {
            Value = value;
        }

        /// <summary>
        /// 値
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// EqualsCore
        /// </summary>
        /// <param name="other">比較する値</param>
        /// <returns>同じときTrue</returns>
        protected override bool EqualsCore(WeatherForecastDate other)
        {
            return Value == other.Value;
        }
    }
}