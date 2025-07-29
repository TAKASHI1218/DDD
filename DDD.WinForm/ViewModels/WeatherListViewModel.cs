using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public class WeatherListViewModel : ViewModelBase
    {

        private IWeatherRepository _weather;

        /// <summary>
        /// コンストラクタでWeatherListViewModelWeatherに設定する
        /// </summary>
        /// <param name="weather"></param>
        public WeatherListViewModel(IWeatherRepository weather)
        {
            _weather = weather;

            // 引数のweathreをWeatherListViewModelWeatherのリストに設定していく
            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }
        }

        /// <summary>
        /// Weathersは画面一覧のリストなのでバインディングする
        /// リストの場合はリスト専用のViewModel(=WeatherListViewModelWeather)を設定する
        /// </summary>
        public BindingList<WeatherListViewModelWeather> Weathers
        { get; set; } = new BindingList<WeatherListViewModelWeather>();
    }
}
