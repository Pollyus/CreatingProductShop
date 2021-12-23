using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OrderStatusRepositorySQL : IRepository<OrderStatus>
    {
        private ProductContext dataBase;

        public OrderStatusRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<OrderStatus> GetList()
        {
            return dataBase.OrderStatus.ToList();
        }

        public OrderStatus GetItem(int id)
        {
            return dataBase.OrderStatus.Find(id);
        }

        public void Create(OrderStatus item)
        {
            dataBase.OrderStatus.Add(item);
        }

        public void Update(OrderStatus item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderStatus item = dataBase.OrderStatus.Find(id);
            if (item != null)
            {
                dataBase.OrderStatus.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}
