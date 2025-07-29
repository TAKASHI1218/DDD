using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using DDD.WinForm.ViewModels;
using System.ComponentModel;

namespace DDD.Domain.ViewModels
{
    /// <summary>
    /// 画面表示のモデルクラス
    /// </summary>
    public class WeatherLatestViewModel:ViewModelBase
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
        private string _areaIdText = string.Empty;

        public string AreaIdText
        {
            get { return _areaIdText; }
            set
            {
                SetProperty(ref _areaIdText, value);
            }
        }

        /// <summary>
        /// データ取得日(表示)
        /// </summary>
        private string _datadateText = string.Empty;

        public string DataDateText
        {
            get { return _datadateText; }
            set
            {
                SetProperty(ref _datadateText, value);
            }
        }

        /// <summary>
        /// 状態(表示)
        /// </summary>
        private string _conditiontext = string.Empty;

        public string ConditionText
        {
            get { return _conditiontext; }
            set
            {
                SetProperty(ref _conditiontext, value);
            }
        }

        /// <summary>
        /// 温度(表示)
        /// </summary>
        private string _temperaturetext = string.Empty;

        public string TemperatureText
        {
            get { return _temperaturetext; }
            set
            {
                SetProperty(ref _temperaturetext, value);
            }
        }

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
