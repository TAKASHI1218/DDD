using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    internal class SQLiteHelper
    {
        /// <summary>
        /// DB接続文字列
        /// </summary>
        internal const string ConnectionString = @"Data Source=C:\Users\t6134\Desktop\DDD\DDD.db;Version=3;";

        /// <summary>
        /// SQLクエリを実行し、T型の読み取り専用リストを返す
        /// </summary>
        /// <typeparam name="T">レコードを変換したい型</typeparam>
        /// <param name="sql">実行するSQLクエリ</param>
        /// <param name="createEntity">
        /// DBから読み取った1行（SQLiteDataReader）を、T型のオブジェクトに変換する関数
        /// ※Func<SQLiteDataReader→入力, T→出力>
        /// </param>
        /// <returns> T型の読み取り専用リスト</returns>
        internal static IReadOnlyList<T> Query<T>(string sql,Func<SQLiteDataReader,T> createEntity)
        {
            var result = new List<T>();
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(createEntity(reader));
                    }
                }
            }

            return result;
        }
    }
}
