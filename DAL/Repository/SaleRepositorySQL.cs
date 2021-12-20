using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class SaleRepositorySQL : IRepository<Sale>
    {
        private ProductContext dataBase;

        public SaleRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<Sale> GetList()
        {
            return dataBase.Sales.ToList();
        }

        public Sale GetItem(int id)
        {
            return dataBase.Sales.Find(id);
        }

        public void Create(Sale item)
        {
            dataBase.Sales.Add(item);
        }

        public void Update(Sale item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Sale item = dataBase.Sales.Find(id);
            if (item != null)
            {
                dataBase.Sales.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}