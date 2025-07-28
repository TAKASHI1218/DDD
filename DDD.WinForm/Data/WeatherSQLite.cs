using DDD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Date
{
    /// <summary>
    /// SQL取得
    /// </summary>
    internal class WeatherSQLite
    {
        /// <summary>
        /// エリアIDのデータを取得
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <returns></returns>
        public static DataTable GetLatest(int areaId)
        {
            string sql = @"select DataDate,Condition,Temperature from Weather where AreaId = @AreaId order by DataDate desc LIMIT 1";

            DataTable dt = new DataTable();
            using (var connection = new SQLiteConnection(CommonConst.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}
