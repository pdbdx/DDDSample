using DDD.Domain.ValueObjects;

namespace DDDExample.Domain.ValueObjects.WeatherForecast
{
    /// <summary>
    /// エリアID
    /// </summary>
    public sealed class TemperatureC : ValueObject<TemperatureC>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public TemperatureC(int value)
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
        protected override bool EqualsCore(TemperatureC other)
        {
            return Value == other.Value;
        }
    }
}