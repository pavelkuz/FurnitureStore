using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public interface IGoodsRepository
    {
        List<Goods> GetAllFurnitures();

        void Save(Goods goods);

        Goods GetFurnitureById(Guid id);

        void RemoveFurnitureById(Guid id);

        void UpdateFurniture(Goods goods);

        List<Goods> Add(Goods goods, List<Goods> allGoods);

        List<Goods> Buy(List<Goods> goods, User user);

        List<Goods> GetAllFurnituresInCart(User user);
    }
}