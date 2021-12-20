using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repository
{
    public class OrderRepositorySQL : IRepository<Order>
    {
        private ProductContext db;
        public OrderRepositorySQL(ProductContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Order> GetList()
        {
            return db.Order.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Order.Find(id);
        }

        public void Create(Order item)
        {
            //item.Id = 4;
            db.Order.Add(item);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order item = db.Order.Find(id);
            if (item != null)
                db.Order.Remove(item);
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}