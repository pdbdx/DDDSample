using DDD.Domain.ValueObjects;

namespace DDDExample.Domain.ValueObjects.WeatherForecast
{
    /// <summary>
    /// エリアID
    /// </summary>
    public sealed class Summary : ValueObject<Summary>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public Summary(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 値
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// EqualsCore
        /// </summary>
        /// <param name="other">比較する値</param>
        /// <returns>同じときTrue</returns>
        protected override bool EqualsCore(Summary other)
        {
            return Value == other.Value;
        }
    }
}