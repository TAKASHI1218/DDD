// ValueOojectの基底クラス
namespace DDD.Domain.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// Object.Equals をオーバーライド（参照比較→値比較へ）
        /// </summary>
        /// <param name="obj">比較するクラス(T)</param>
        /// <returns>EqualsCore関数の結果</returns>
        public override bool Equals(object obj)
        {
            var vo = obj as T;
            if (vo == null)
            {
                return false;
            }

            return EqualsCore(vo);
        }

        /// <summary>
        /// 別インスタンスでも値が一致ならばイコールとする
        /// </summary>
        /// <param name="vo1">比較対象のクラスのインスタンス1</param>
        /// <param name="vo2">比較対象のクラスのインスタンス2</param>
        /// <returns>値による比較の結果</returns>
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        /// <summary>
        /// 別インスタンスで値が一致ならばイコールとする(書かないと警告が出るため追記)
        /// </summary>
        /// <param name="vo1">比較対象のクラスのインスタンス1</param>
        /// <param name="vo2">比較対象のクラスのインスタンス2</param>
        /// <returns>値による比較の結果</returns>
        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        /// <summary>
        /// 実際の比較ロジックは派生クラスが定義
        /// 派生クラスが 比較対象となる値プロパティの比較処理を実装する
        /// </summary>
        /// <param name="other">比較するクラスのインスタンス</param>
        /// <returns>派生クラスに委ねる</returns>
        protected abstract bool EqualsCore( T other);

        /// <summary>
        /// 未実装 一旦不要
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}