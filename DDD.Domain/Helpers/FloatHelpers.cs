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
        /// Floatを丸めて文字列で返す
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="decimalPoint">小数点の位置</param>
        /// <returns>丸まった値の文字列</returns>
        public static string RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
