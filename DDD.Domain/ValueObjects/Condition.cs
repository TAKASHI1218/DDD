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
        /// 不明
        /// </summary>
        public static readonly Condition None = new Condition(0);

        /// <summary>
        /// 晴れ
        /// </summary>
        public static readonly Condition Sunny = new Condition(1);

        /// <summary>
        /// 曇り
        /// </summary>
        public static readonly Condition Cloudy = new Condition(2);

        /// <summary>
        /// 雨
        /// </summary>
        public static readonly Condition Rain = new Condition(3);

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
        /// this(コンストラクタのValue)の値で各プロパティを比較し状態("晴れ"など)を返す
        /// </summary>
        public string DisplayValue
        {
            get 
            {  
                if(this == Sunny)
                {
                    return "晴れ";
                }
                if (this == Cloudy)
                {
                    return "曇り";
                }
                if (this == Rain)
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
