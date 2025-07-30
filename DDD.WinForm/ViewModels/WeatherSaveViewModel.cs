using DDD.Domain.ValueObjects;
using System;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel: ViewModelBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WeatherSaveViewModel()
        {
            DataDateVlaue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;
        }

        /// <summary>
        /// エリアId
        /// Comboboxなのでobject型
        /// </summary>
        public object SelectedAreaId { get; set; }

        /// <summary>
        /// データ取得日
        /// </summary>
        public DateTime DataDateVlaue { get; set; }

        /// <summary>
        /// 状態
        /// Comboboxなのでobject型
        /// </summary>
        public object SelectedCondition { get; set; }

        /// <summary>
        /// 温度
        /// テキストボックスなのでstring型
        /// </summary>
        public string TemperatureText { get; set; }
    }
}
