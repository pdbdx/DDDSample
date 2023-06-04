using DDD.Domain.ValueObjects;

namespace DDDExample.Domain.ValueObjects.WeatherForecast
{
    /// <summary>
    /// エリアID
    /// </summary>
    public sealed class TemperatureF : ValueObject<TemperatureF>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public TemperatureF(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 値
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// EqualsCore
        /// </summary>
        /// <param name="other">比較する値</param>
        /// <returns>同じときTrue</returns>
        protected override bool EqualsCore(TemperatureF other)
        {
            return Value == other.Value;
        }
    }
}