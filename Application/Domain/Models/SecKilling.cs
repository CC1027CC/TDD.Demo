namespace Application.Domain.Models
{
    /// <summary>
    /// 秒杀数据
    /// </summary>
    public class SecKilling
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 当前数量
        /// </summary>
        public int CurrentQty { get; set; }

        /// <summary>
        /// 秒杀总数量
        /// </summary>
        public int TotalQty { get; set; }
    }
}
