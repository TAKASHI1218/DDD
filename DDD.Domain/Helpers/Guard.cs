using DDD.Domain.Exceptions;
using DDD.Domain.ValueObjects;

namespace DDD.Domain.Helpers
{
    public static class Guard
    {
        /// <summary>
        /// 引数の値がnullの場合は例外を出す
        /// </summary>
        /// <param name="o">対象の値</param>
        /// <param name="message">例外メッセージ</param>
        /// <exception cref="InputException"></exception>
        public static void IsNull(object o, string message)
        {
            if(o == null)
            {
                throw new InputException(message);
            } 
        }

        /// <summary>
        /// 引数の値がFloatではない場合は例外を出す
        /// </summary>
        /// <param name="text">対象の値</param>
        /// <param name="message">例外メッセージ</param>
        /// <returns></returns>
        /// <exception cref="InputException"></exception>
        public static float IsFloat(string text, string message)
        {
            float floatValue;
            if (!float.TryParse(text, out floatValue))
            {
                throw new InputException("温度の入力に誤りがあります");
            }
            return floatValue;
        }
    }
}
