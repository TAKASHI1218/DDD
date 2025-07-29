using DDD.Domain.ValueObjects;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        /// <summary>
        /// 完全コンストラクタパターン
        /// areaNameはnullの場合はこちらのコンストラクタが適用される
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <param name="dataDate">データ取得日</param>
        /// <param name="condition">状態</param>
        /// <param name="temperature">温度</param>
        public WeatherEntity(int areaId,
                          DateTime dataDate,
                          int condition,
                          float temperature)
         : this(areaId, string.Empty, dataDate, condition, temperature)
        {
        }

        /// <summary>
        /// 完全コンストラクタパターン(エリア名あり)
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <param name="areaName">エリア名</param> 
        /// <param name="dataDate">データ取得日</param>
        /// <param name="condition">状態</param>
        /// <param name="temperature">温度</param>
        public WeatherEntity(int areaId,
                       string areaName,
                       DateTime dataDate,
                       int condition,
                       float temperature)
        {
            AreaId = new AreaId(areaId);
            AreaName = areaName;
            DataDate = dataDate;
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        /// <summary>
        /// エリアID
        /// </summary>
        public AreaId AreaId { get; }

        /// <summary>
        /// エリア名
        /// (Areaテーブルから取得する)
        /// </summary>
        public string AreaName { get; }

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
