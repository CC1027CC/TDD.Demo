using Application.Domain.Models;
using Application.Services.Dtos;

namespace Application.Services
{
    /// <summary>
    /// 秒杀服务
    /// </summary>
    public interface ISeckillingService
    {
        /// <summary>
        /// 设置秒杀数量
        /// </summary>
        /// <param name="goods">商品</param>
        /// <param name="qty">数量</param>
        void SetQty(Goods goods, int qty);

        /// <summary>
        /// 销售
        /// </summary>
        /// <returns>返回销售的商品信息</returns>
        Goods Sale(SeckillingSaleDto dto);
    }
}
