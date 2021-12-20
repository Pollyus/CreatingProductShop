using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class OrderLinesRepositorySQL : IRepository<OrderLines>
    {
        private ProductContext db;
        public OrderLinesRepositorySQL(ProductContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<OrderLines> GetList()
        {
            return db.OrderLines.ToList();
        }

        public OrderLines GetItem(int id)
        {
            return db.OrderLines.Find(id);
        }

        public void Create(OrderLines item)
        {
            db.OrderLines.Add(item);
        }

        public void Update(OrderLines item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderLines item = db.OrderLines.Find(id);
            if (item != null)
                db.OrderLines.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
