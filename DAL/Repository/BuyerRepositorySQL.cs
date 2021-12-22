using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class BuyerRepositorySQL : IRepository<Buyer>
    {
        private ProductContext dataBase;

        public BuyerRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<Buyer> GetList()
        {
            return dataBase.Buyers.ToList();
        }

        public Buyer GetItem(int id)
        {
            return dataBase.Buyers.Find(id);
        }

        public void Create(Buyer item)
        {
            //item.TipeId = 1;
            dataBase.Buyers.Add(item);
        }

        public void Update(Buyer item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Buyer item = dataBase.Buyers.Find(id);
            if (item != null)
            {
                dataBase.Buyers.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}
