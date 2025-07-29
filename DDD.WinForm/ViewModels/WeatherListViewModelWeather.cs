using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    /// <summary>
    /// リスト専用のViewModel
    /// </summary>
    public sealed class WeatherListViewModelWeather
    {
        private WeatherEntity _entity;

        /// <summary>
        /// コンストラクタでWeatherEntityを受けとりWeatherListViewModelWeatherに設定する
        /// </summary>
        /// <param name="entity"></param>
        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// エリアID(表示)
        /// </summary>
        public string AreaId => _entity.AreaId.DisplayValue;

        /// <summary>
        /// エリア名(表示)
        /// </summary>
        public string AreaName => _entity.AreaName;

        /// <summary>
        /// データ取得日(表示)
        /// </summary>
        public string DataDate => _entity.DataDate.ToString();

        /// <summary>
        /// 状態(表示)
        /// </summary>
        public string Condition => _entity.Condition.DisplayValue;

        /// <summary>
        /// 温度(表示)
        /// </summary>
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }
}
