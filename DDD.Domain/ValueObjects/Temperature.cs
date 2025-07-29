using DDD.Domain.Helpers;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        /// <summary>
        /// 温度の単位
        /// </summary>
        public const string UnitName = "℃";

        /// <summary>
        /// 温度の小数点の位置
        /// </summary>
        public const int DecimalPoint = 2;

        /// <summary>
        /// コンストラクタでfloatの値をValueに設定
        /// </summary>
        /// <param name="value">float型の値=温度</param>
        public Temperature(float value)
        {
            Value = value;
        }

        /// <summary>
        /// 原型の温度の値(読み取り専用)
        /// </summary>
        public float Value { get; }

        /// <summary>
        /// 温度表示(スペースあり)
        /// </summary>
        public string DisplayValueWithUnitSpace
        {
            get
            {
                return Value.RoundString(DecimalPoint) + " " + UnitName;  
            }
        }

        /// <summary>
        /// 温度表示(スペースなし)
        /// </summary>
        public string DisplayValueWithUnit
        {
            get
            {
                return Value.RoundString(DecimalPoint) + UnitName;
            }
        }

        /// <summary>
        /// 異なるインスタンスでも値が同じならイコール
        /// </summary>
        /// <param name="other">Temperatureクラスのインスタンス</param>
        /// <returns>値判定の結果</returns>
        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
