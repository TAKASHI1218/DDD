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

        // -- SQLの行を返す処理 Start -- // 

        /// <summary>
        /// SQLクエリを実行し、T型の読み取り専用リストを返す(パラメータなし)
        /// </summary>
        /// <typeparam name="T">レコードを変換したい型</typeparam>
        /// <param name="sql">実行するSQLクエリ</param>
        /// <param name="createEntity">T型の読み取り専用リスト
        /// DBから読み取った1行（SQLiteDataReader）を、T型のオブジェクトに変換する関数
        /// ※Func<SQLiteDataReader→入力, T→出力>
        /// </param>
        /// <returns> T型の読み取り専用リスト</returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }

        /// <summary>
        /// SQLクエリを実行し、T型の読み取り専用リストを返す(パラメータあり)
        /// </summary>
        /// <typeparam name="T">レコードを変換したい型</typeparam>
        /// <param name="sql">実行するSQLクエリ</param>
        /// <param name="parameters">パラメータ</param>
        /// <param name="createEntity">
        /// DBから読み取った1行（SQLiteDataReader）を、T型のオブジェクトに変換する関数
        /// ※Func<SQLiteDataReader→入力, T→出力>
        /// </param>
        /// <returns> T型の読み取り専用リスト</returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity)
        {
            var result = new List<T>();
            using (var connection = 
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                // パラメータがある場合は設定する
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

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

        // -- SQLの行を返す処理 End -- // 

        // -- SQLのオブジェクトを返す処理 Start -- // 

        /// <summary>
        /// SQLクエリを実行し、T型のオブジェクト返す、結果がない場合はnullを返す(パラメータなし)
        /// </summary>
        /// <typeparam name="T">返却される型</typeparam>
        /// <param name="sql">実行するSQLクエリ</param>
        /// <param name="createEntity">
        /// DBから読み取ったクエリ（SQLiteDataReader）を、T型を生成する関数
        /// ※Func<SQLiteDataReader→入力, T→出力>
        /// </param>
        /// <param name="nullEntity">結果が存在しない場合に返却する(呼び出し側でnullを渡す)</param>
        /// <returns>T型のオブジェクト or null</returns>
        internal static T QuerySingle<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            return QuerySingle<T>(sql, null, createEntity, nullEntity);
        }

        /// <summary>
        /// SQLクエリを実行し、T型のオブジェクト返す、結果がない場合はnullを返す(パラメータあり)
        /// </summary>
        /// <typeparam name="T">返却される型</typeparam>
        /// <param name="sql">実行するSQLクエリ</param>
        /// <param name="parameters">パラメータ</param>
        /// <param name="createEntity">
        /// DBから読み取ったクエリ（SQLiteDataReader）を、T型を生成する関数
        /// ※Func<SQLiteDataReader→入力, T→出力>
        /// </param>
        /// <param name="nullEntity">結果が存在しない場合に返却する(呼び出し側でnullを渡す)</param>
        /// <returns>T型のオブジェクト or null</returns>
        internal static T QuerySingle<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                // パラメータがある場合設定する
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return createEntity(reader);
                    }
                }
            }

            return nullEntity;
        }

        // -- SQLのオブジェクトを返す処理 End -- // 

    }
}
