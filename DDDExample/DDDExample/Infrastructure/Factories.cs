using DDDExample.Domain;
using DDDExample.Domain.Repositories;
using DDDExample.Infrastructure.DataAccess.Dummy;
using DDDExample.Infrastructure.DataAccess.MySQL;

namespace DDDExample.Infrastructure
{
    /// <summary>
    /// ファクトリー
    /// </summary>
    public static class Factories
    {
        /// <summary>
        /// 天気予報リポジトリのインスタンスを作成します。
        /// </summary>
        /// <returns>天気予報リポジトリのインスタンス</returns>
        public static IWeatherForecastRepository CreateWeatherForecast()
        {
            var settings = new AppSettings();
#if DEBUG
            if (settings.DbKind == 0)
            {
                // ダミーデータ
                return new WeatherForecastDummy();
            }
#endif
            // MySQL
            return new WeatherForecastMySql();
        }
    }
}
