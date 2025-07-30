using DDD.Domain.Exceptions;

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
    }
}
