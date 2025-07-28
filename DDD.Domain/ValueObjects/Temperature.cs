using DDD.Domain.Common;
using System.Runtime.CompilerServices;



namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        // コンストラクタでfloatの値を設定(読み取り専用)
        public Temperature(float value)
        {
            Value = value;
        }

        public float Value { get; }
        public string? DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint) + " " +  UnitName;   
            }
        }

        // 異なるインスタンスでも値が同じならイコール
        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
