using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WeatherSaveViewModel(
            IWeatherRepository weather,
            IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;
            DataDateVlaue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;

            // エリアをAreasに入れていく
            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
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

        /// <summary>
        /// 地域テーブルを運ぶEntity
        /// </summary>
        public BindingList<AreaEntity> Areas
        { get; set; } = new BindingList<AreaEntity>();

        /// <summary>
        /// 状態をバインディング
        /// </summary>
        public BindingList<Condition> Conditions { get; set; }
         = new BindingList<Condition>(Condition.ToList());

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <exception cref="InputException">例外</exception>
        public void Save()
        {
            // SeletedAreaIdのチェック
            Guard.IsNull(SelectedAreaId, "エリアを選択してください");

            // Temperatureのチェック
            var temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            // Entityを作ってSaveに渡す
            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DataDateVlaue,
                Convert.ToInt32(SelectedCondition),
                temperature
                );

            _weather.Save(entity); // →ここ以降はSQLiteの領域
        }
    }
}
