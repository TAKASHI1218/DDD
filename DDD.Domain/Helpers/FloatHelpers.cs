using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Helpers
{
    public static class FloatHelpers
    {
        /// <summary>
        /// Floatを指定した小数点で四捨五入で文字列にして返す
        /// </summary>
        /// <param name="value">値(Float)</param>
        /// <param name="decimalPoint">小数点の位置</param>
        /// <returns>四捨五入したFloatの値の文字列</returns>
        public static string RoundString(this float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
