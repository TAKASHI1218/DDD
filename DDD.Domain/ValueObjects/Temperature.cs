using DDD.Domain.Common;
using System.Runtime.CompilerServices;



namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        public const string UnitName = "℃"; // Temperature unit
        public const int DecimalPoint = 2;

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

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
