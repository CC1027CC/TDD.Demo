using System;
using System.Linq;
using Application.Domain.Models;
using Application.Services;
using Application.Services.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Xunit;

namespace Application.Test
{
    public class SeckillingTest : TestBase
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly ISeckillingService _seckillingService;
        private readonly IGoodsServices _goodsServices;
        public SeckillingTest() : base()
        {
            MEMORY_DB_NAME = "Seckilling";
            services.AddTransient<ISeckillingService, SeckillingService>();
            _serviceProvider = services.BuildServiceProvider();
            _seckillingService = _serviceProvider.GetRequiredService<ISeckillingService>();

            _goodsServices = MockIGoodsServices();
        }

        private IGoodsServices MockIGoodsServices()
        {
            var mock = new Mock<IGoodsServices>();

            mock.Setup(s => s.GetGoods(It.IsAny<int>()))
                .Returns((int id) =>
                 {
                     var goodss = new[]
                     {
                        new Goods{Id = 1,Name = "手机1",Price = 1000_00,Qty = 20},
                        new Goods{Id = 2,Name = "手机",Price = 1000_00,Qty = 20}
                     };
                     return goodss.First(s => s.Id == id);
                 });

            return mock.Object;
        }

        [Fact(DisplayName = "设置秒杀商品及数量")]
        public void SetQtyTest()
        {
            var goods = _goodsServices.GetGoods(1);
            Should.Throw<UserException>(() => _seckillingService.SetQty(goods, 100));
            _seckillingService.SetQty(goods, 10);
        }

        [Fact(DisplayName = "销售秒杀产品")]
        public void SaleTest()
        {
            var goods = _goodsServices.GetGoods(2);
            _seckillingService.SetQty(goods, 10);
            Goods saleGoods = null;

            var dto = new SeckillingSaleDto(goods.Id, 1);

            // 前5(50%)名打1折
            for (int i = 0; i < 5; i++)
            {
                saleGoods = _seckillingService.Sale(dto);
                saleGoods.Id.ShouldBe(goods.Id);
                saleGoods.Price.ShouldBe(goods.Price / 10);
            }
            // 后5(50%)名打2折
            for (int i = 0; i < 5; i++)
            {
                saleGoods = _seckillingService.Sale(dto);
                saleGoods.Id.ShouldBe(goods.Id);
                saleGoods.Price.ShouldBe(goods.Price / 10 * 2);
            }

            // 超出下单
            Should.Throw<UserException>(()=> _seckillingService.Sale(dto),"库存不够");
        }
    }
}
