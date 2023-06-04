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
        string _connectionString;

        public WeatherForecastMySql()
        {
            var settings = new AppSettings();
            _connectionString = settings.MySQLConnectionString;
        }

        /// <summary>
        /// 最新の天気予報を1件取得
        /// </summary>
        /// <returns></returns>
        public WeatherForecastEntity GetLatest()
        {
            string sql = @"
                    SELECT date,
                           temperature_c,
                           temperature_f,
                           summary
                    FROM weather_forecast
                    ORDER BY date desc
                    LIMIT 1
                    ";

            using var connection = new MySqlConnection(_connectionString);
            // 接続の確立
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            // 1行読み込み
            reader.Read();
            return new WeatherForecastEntity(
                    Convert.ToDateTime(reader["date"]),
                    Convert.ToInt32(reader["temperature_c"]),
                    Convert.ToInt32(reader["temperature_f"]),
                    Convert.ToString(reader["summary"]) ?? string.Empty);
        }

        /// <summary>
        /// 日付の範囲指定で天気予報を取得
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IReadOnlyList<WeatherForecastEntity> GetByDateRange(GetByDateRangeParams parameters)
        {
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
            connection.Open();

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@StartDate", parameters.StartDate);
            command.Parameters.AddWithValue("@EndDate", parameters.EndDate);
            // SELECT文を実行
            using var reader = command.ExecuteReader();

            var weatherForecastEntityList = new List<WeatherForecastEntity> ();
            // SELECT文を実行し、結果を1行ずつコンソールに表示
            while (reader.Read())
            {
                weatherForecastEntityList.Add(
                    new WeatherForecastEntity(
                            Convert.ToDateTime(reader["date"]), 
                            Convert.ToInt32(reader["temperature_c"]),
                            Convert.ToInt32(reader["temperature_f"]),
                            Convert.ToString(reader["summary"]) ?? string.Empty
                        )
                );
            }
            return weatherForecastEntityList;
        }

        /// <summary>
        /// 天気予報を登録
        /// </summary>
        /// <param name="entity"></param>
        public void Save(WeatherForecastEntity entity)
        {
            string insert = @"
                INSERT INTO weather_forecast
                (date,temperature_c,temperature_f,summary)
                values
                (@Date,@TemperatureC,@TemperatureF,@Summary)
                ";

            using var connection = new MySqlConnection(_connectionString);
            connection.Open();

            using var command = new MySqlCommand(insert, connection);
            command.Parameters.AddWithValue("@Date", entity.WeatherForecastDate.Value);
            command.Parameters.AddWithValue("@TemperatureC", entity.TemperatureC.Value);
            command.Parameters.AddWithValue("@TemperatureF", entity.TemperatureF.Value);
            command.Parameters.AddWithValue("@Summary", entity.Summary.Value);

            command.ExecuteNonQuery();
        }
    }
}
