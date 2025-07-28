namespace DDD.Domain.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        // Object.Equals をオーバーライド（参照比較→値比較へ）
        public override bool Equals(object obj)
        {
            var vo = obj as T;
            if (vo == null)
            {
                return false;
            }

            return EqualsCore(vo);
        }

        // 別インスタンスでも値が一致ならばイコールとする
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        // 書かないと警告が出るため追記
        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        // 実際の比較ロジックは派生クラスが定義
        // 派生クラスが 比較対象となる値プロパティの比較処理を実装する
        protected abstract bool EqualsCore( T other);

        // 未実装 一旦不要
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}