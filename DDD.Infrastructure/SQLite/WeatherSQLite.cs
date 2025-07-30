using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    /// <summary>
    /// SQLiteにあるWeahterのクラス
    /// </summary>
    public class WeatherSQLite : IWeatherRepository
    {
        /// <summary>
        /// エリアIdをパラメータにしてWeatherEntityオブジェクトを取得
        /// </summary>
        /// <param name="areaId">エリアId</param>
        /// <returns>WeatherEntityオブジェクト</returns>
        public WeatherEntity? GetLatest(int areaId)
        {
            string sql = @"
select DataDate,
        Condition,
        Temperature 
        from Weather 
where AreaId = @AreaId 
order by DataDate 
desc LIMIT 1
";

            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId",areaId)
                }.ToArray(),
                reader=>
                {
                    return new WeatherEntity(
                             areaId,
                             Convert.ToDateTime(reader["DataDate"]),
                             Convert.ToInt32(reader["Condition"]),
                             Convert.ToSingle(reader["Temperature"]));
                 }
                ,null);
        }

        /// <summary>
        /// Weatherテーブルの一覧を取得する
        /// エリア名はAreaテーブルからエリアIdを紐づけして取得
        /// </summary>
        /// <returns>Weatherテーブルの一覧を取得</returns>
        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
select A.AreaId,
         ifnull(B.AreaName,'') as AreaName,
         A.DataDate,
         A.Condition,
         A.Temperature
from Weather A
left outer join Areas B
on A.AreaId = B.AreaId
";

            return SQLiteHelper.Query(sql,
                reader =>
                {
                    return new WeatherEntity(
                           Convert.ToInt32(reader["AreaId"]),
                           Convert.ToString(reader["AreaName"]),
                           Convert.ToDateTime(reader["DataDate"]),
                           Convert.ToInt32(reader["Condition"]),
                           Convert.ToSingle(reader["Temperature"]));
                });
        }

        public void Save(WeatherEntity weather)
        {
            throw new NotImplementedException();
        }
    }
}
