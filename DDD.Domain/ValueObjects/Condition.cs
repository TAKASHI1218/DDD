using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public sealed class Condition : ValueObject<Condition>
    {
        /// <summary>
        /// コンストラクタで状態の値をValueに設定
        /// </summary>
        /// <param name="value">状態の値=数値</param>
        public Condition(int value)
        {
            Value = value;
        }

        /// <summary>
        /// 状態の数値(読み取り専用)
        /// </summary>
        public int Value { get;}

        /// <summary>
        /// 状態の表示
        /// </summary>
        public string DisplayValue
        {
            get 
            {  
                if(this.Value == 1)
                {
                    return "晴れ";
                }
                if (this.Value == 2)
                {
                    return "曇り";
                }
                if (this.Value == 3)
                {
                    return "雨";
                }

                return "不明";
            }
        }

        /// <summary>
        /// 異なるインスタンスでも値が同じならイコール
        /// </summary>
        /// <param name="other">Conditionクラスのインスタンス</param>
        /// <returns>値判定の結果</returns>
        protected override bool EqualsCore(Condition other)
        {
            return this.Value == other.Value;
        }
    }
}
