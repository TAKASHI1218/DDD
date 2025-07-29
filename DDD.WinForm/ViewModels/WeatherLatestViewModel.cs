using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.ValueObjects;

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
        /// コンストラクタ
        /// </summary>
        /// <param name="weather"></param>
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
