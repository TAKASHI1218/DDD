using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System.ComponentModel;

namespace DDD.Domain.ViewModels
{
    /// <summary>
    /// 画面表示のモデルクラス
    /// </summary>
    public class WeatherLatestViewModel:INotifyPropertyChanged
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
                if (_areaIdText == value)
                {
                    return;
                }

                _areaIdText = value;
                OnPropertyChanged(nameof(AreaIdText));
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
                if (_datadateText == value)
                {
                    return;
                }

                _datadateText = value;
                OnPropertyChanged(nameof(DataDateText));
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
                if (_conditiontext == value)
                {
                    return;
                }

                _conditiontext = value;
                OnPropertyChanged(nameof(ConditionText));
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
                if (_temperaturetext == value)
                {
                    return;
                }

                _temperaturetext = value;
                OnPropertyChanged(nameof(TemperatureText));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

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

            // 値が変わったらデータバインドする。（""はすべてのデータに適用される）
            OnPropertyChanged("");
        }

        /// <summary>
        /// PropertyChangedがnullではなかったらInvokeする
        /// これが呼ばれるとViewとViewModelで同期される(データバインドされる)
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
