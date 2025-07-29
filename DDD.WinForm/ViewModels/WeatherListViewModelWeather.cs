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
    }
}
