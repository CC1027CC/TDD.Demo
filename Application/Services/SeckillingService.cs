using Application.Domain;
using Application.Domain.Models;
using Application.Services.Dtos;

namespace Application.Services
{
    /// <summary>
    /// 秒杀服务
    /// </summary>
    public class SeckillingService : ISeckillingService
    {
        private readonly ApplicationDbContext _dbContext;
        public SeckillingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Goods Sale(SeckillingSaleDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void SetQty(Goods goods, int qty)
        {
            throw new System.NotImplementedException();
        }
    }
}
