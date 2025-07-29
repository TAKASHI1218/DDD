using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        /// <summary>
        /// Areas テーブルの全データを取得し、AreaEntity の読み取り専用リストとして返す
        /// </summary>
        /// <returns>読み取り専用のAreaEntity</returns>
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"select AreaId, AreaName from Areas";

            // sqlのクエリを実行しAreaEntityを返す
            return SQLiteHelper.Query<AreaEntity>(sql, CreateEntity);
        }

        /// <summary>
        /// SQLiteDataReader の1行を AreaEntity にマッピングしてインスタンスを返す
        /// </summary>
        /// <param name="reader">読み取り専用のデータストリーム</param>
        /// <returns>変換された AreaEntity インスタンス</returns>
        private AreaEntity CreateEntity(SQLiteDataReader reader)
        {
            return new AreaEntity(
                                Convert.ToInt32(reader["AreaId"]), 
                                Convert.ToString(reader["AreaName"])
                                );
        }
    }
}
