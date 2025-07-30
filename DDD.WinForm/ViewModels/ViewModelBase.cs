using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    /// <summary>
    /// MVVM支援ツールのプリズムののバインダブルベースのコードを流用
    /// PropertyChangedがnullではなかったらInvokeする
    /// これが呼ばれるとViewとViewModelで同期される(データバインドされる)
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// データをセット(バインド)する
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">セットする値</param>
        /// <param name="value">セットされる値</param>
        /// <param name="propertyName"></param>
        /// <returns>セットしていればTrue</returns>
        protected bool SetProperty<T>(ref T field,
            T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }

            return true;
        }

        /// <summary>
        /// 現在日時を取得
        /// ※virtualは基底クラスで定義されたメソッドやプロパティを、
        /// 派生クラスでオーバーライド（上書き）可能にするための修飾子
        /// </summary>
        /// <returns>現在日時</returns>
        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
