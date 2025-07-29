using DDD.Domain.ValueObjects;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        /// <summary>
        /// 完全コンストラクタパターン
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <param name="dataDate">データ取得日</param>
        /// <param name="condition">状態</param>
        /// <param name="temperature">温度</param>
        public WeatherEntity(int areaId, DateTime dataDate, int condition, float temperature)
        {
            AreaId = areaId;
            DataDate = dataDate;
            Condition =  new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        /// <summary>
        /// エリアID
        /// </summary>
        public int AreaId { get; }

        /// <summary>
        /// データ取得日
        /// </summary>
        public DateTime DataDate { get; }

        /// <summary>
        /// 状態
        /// </summary>
        public Condition Condition { get; }

        /// <summary>
        /// 温度
        /// </summary>
        public Temperature Temperature { get;}
    }
}
