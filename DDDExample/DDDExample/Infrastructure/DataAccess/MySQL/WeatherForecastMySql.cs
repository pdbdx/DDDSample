using DDDExample.Domain;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Repositories;
using DDDExample.Domain.Repositories.Parameters.WeatherForecast;
using MySqlConnector;

namespace DDDExample.Infrastructure.DataAccess.MySQL
{
    public class WeatherForecastMySql : IWeatherForecastRepository
    {
        // 接続文字列
        private readonly string _connectionString;

        // ロガー作成
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public WeatherForecastMySql()
        {
            var settings = new AppSettings();
            _connectionString = settings.MySQLConnectionString;
        }

        /// <summary>
        /// 最新の天気予報を1件取得
        /// </summary>
        /// <returns></returns>
        public async Task<WeatherForecastEntity> GetLatest()
        {
            logger.Info("Start GetLatest");
            string sql = @"
                    SELECT date,
                           temperature_c,
                           temperature_f,
                           summary
                    FROM weather_forecast
                    ORDER BY date desc
                    LIMIT 1
                    ";

            await using var connection = new MySqlConnection(_connectionString);
            // 接続の確立
            await connection.OpenAsync();

            using var command = new MySqlCommand(sql, connection);
            using var reader = await command.ExecuteReaderAsync();
            // 1行読み込み
            reader.Read();

            logger.Info("End GetLatest");
            return new WeatherForecastEntity(
                reader.GetDateTime("date"),
                reader.GetInt32("temperature_c"),
                reader.GetInt32("temperature_f"),
                reader.GetString("summary") ?? string.Empty);

        }

        /// <summary>
        /// 日付の範囲指定で天気予報を取得
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<WeatherForecastEntity>> GetByDateRange(GetByDateRangeParams parameters)
        {
            logger.Info("Start GetByDateRange");
            string sql = @"
                    SELECT date,
                           temperature_c,
                           temperature_f,
                           summary
                    FROM weather_forecast
                    WHERE
                    date >= @StartDate
                    AND
                    date <= @EndDate
                    ORDER BY date desc
                    ";

            using var connection = new MySqlConnection(_connectionString);
            // 接続の確立
            await connection.OpenAsync();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@StartDate", parameters.StartDate);
            command.Parameters.AddWithValue("@EndDate", parameters.EndDate);
            // SELECT文を実行
            await using var reader = await command.ExecuteReaderAsync();

            var weatherForecastEntityList = new List<WeatherForecastEntity> ();
            // SELECT文を実行し、結果を1行ずつコンソールに表示
            while (reader.Read())
            {
                weatherForecastEntityList.Add(new WeatherForecastEntity(
                    reader.GetDateTime("date"),
                    reader.GetInt32("temperature_c"),
                    reader.GetInt32("temperature_f"),
                    reader.GetString("summary") ?? string.Empty));
            }

            logger.Info("End GetByDateRange");
            return weatherForecastEntityList;
        }

        /// <summary>
        /// 天気予報を登録
        /// </summary>
        /// <param name="entity"></param>
        public async Task Save(WeatherForecastEntity entity)
        {
            logger.Info("Start Save");
            string insert = @"
                INSERT INTO weather_forecast
                (date,temperature_c,temperature_f,summary)
                values
                (@Date,@TemperatureC,@TemperatureF,@Summary)
                ";

            await using var connection = new MySqlConnection(_connectionString);
            // 接続の確立
            await connection.OpenAsync();

            using var command = new MySqlCommand(insert, connection);
            command.Parameters.AddWithValue("@Date", entity.WeatherForecastDate.Value);
            command.Parameters.AddWithValue("@TemperatureC", entity.TemperatureC.Value);
            command.Parameters.AddWithValue("@TemperatureF", entity.TemperatureF.Value);
            command.Parameters.AddWithValue("@Summary", entity.Summary.Value);

            await command.ExecuteNonQueryAsync();
            logger.Info("End Save");
        }
    }
}
