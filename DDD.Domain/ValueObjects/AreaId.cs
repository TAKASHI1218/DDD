using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class AreaId : ValueObject<AreaId>
    {
        /// <summary>
        /// 完全コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public AreaId(int value)
        {
            Value = value;
        }

        public int Value { get; }

        protected override bool EqualsCore(AreaId other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// ビジネスロジック、4文字0埋め
        /// </summary>
        public string DisplayValue
        {
            get
            {
                return Value.ToString().PadLeft(4, '0');
            }
        }
    }
}
