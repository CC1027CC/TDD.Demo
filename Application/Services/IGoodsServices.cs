using Application.Domain.Models;

namespace Application.Services
{
    public interface IGoodsServices
    {
        Goods GetGoods(int id);
    }
}
