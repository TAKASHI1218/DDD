using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;

namespace DDD.Domain.ViewModels
{
    /// <summary>
    /// 画面表示のモデルクラス
    /// </summary>
    public class WeatherLatestViewModel
    {
        /// <summary>
        /// メンバ変数
        /// </summary>
        private IWeatherRepository _weather;

        /// <summary>
        /// コンストラクタ引数なし
        /// ① WeatherLatestViewModel() が呼ばれる
        /// ② new WeatherSQLite() が生成される
        /// ③ WeatherLatestViewModel(IWeatherRepository weather) に渡される
        /// ④ _weather にインスタンスが格納される
        /// </summary>
        public WeatherLatestViewModel():this(new WeatherSQLite())
        {
        }

        /// <summary>
        /// コンストラクタ引数あり→引数がなければコンストラクタ引数なしが呼ばれる
        /// </summary>
        /// <param name="weather">IWeatherRepository</param>
        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        /// <summary>
        /// エリアID(表示)
        /// </summary>
        public string? AreaIdText { get; set; } = string.Empty;

        /// <summary>
        /// データ取得日(表示)
        /// </summary>
        public string? DataDateText { get; set; } = string.Empty;

        /// <summary>
        /// 状態(表示)
        /// </summary>
        public string? ConditionText { get; set; } = string.Empty;

        /// <summary>
        /// 温度(表示)
        /// </summary>
        public string? TemperatureText { get; set; } = string.Empty;

        /// <summary>
        /// データ取得
        /// </summary>
        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
