using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Dtos
{
    public class SeckillingSaleDto
    {
        public SeckillingSaleDto(int goodsId,int qty)
        {
            GoodsId = goodsId;
            Qty = qty;
        }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 下单数量
        /// </summary>
        public int Qty { get; set; }
    }
}
