using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.Repository
{
    class ShoppingCartRepositorySQL : IRepository<ShoppingCart>
    {
        private ProductContext dataBase;

        public ShoppingCartRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<ShoppingCart> GetList()
        {
            return dataBase.ShoppingCarts.ToList();
        }

        public ShoppingCart GetItem(int id)
        {
            return dataBase.ShoppingCarts.Find(id);
        }

        public void Create(ShoppingCart item)
        {
            dataBase.ShoppingCarts.Add(item);
        }

        public void Update(ShoppingCart item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ShoppingCart item = dataBase.ShoppingCarts.Find(id);
            if (item != null)
            {
                dataBase.ShoppingCarts.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }

    }
}
