using DDDExample.Domain.Entities;
using DDDExample.Domain.Repositories.Parameters.WeatherForecast;

namespace DDDExample.Domain.Repositories
{
    /// <summary>
    /// 天気予報リポジトリー
    /// </summary>
    public interface IWeatherForecastRepository
    {
        /// <summary>
        /// 最新の値を取得
        /// </summary>
        /// <returns></returns>
        Task<WeatherForecastEntity> GetLatest();

        /// <summary>
        /// 日付の範囲で値を取得
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<WeatherForecastEntity>> GetByDateRange(GetByDateRangeParams parameters);

        /// <summary>
        /// 値を保存
        /// </summary>
        /// <param name="weather"></param>
        Task Save(WeatherForecastEntity weather);
    }
}
