namespace DDD.Domain.Entities
{
    public sealed class AreaEntity
    {

        /// <summary>
        /// コンストラクタ
        /// コンストラクタのみで値設定
        /// </summary>
        /// <param name="areaId">エリアId</param>
        /// <param name="areaname">エリア名</param>
        public AreaEntity(int areaId, string areaname)
        {
            AreaId = areaId;
            AreaName = areaname;
        }

        /// <summary>
        /// エリアId
        /// </summary>
        public int AreaId { get; }

        /// <summary>
        /// エリア名
        /// </summary>
        public string AreaName { get; }
    }
}
