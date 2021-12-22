using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class BrandRepositorySQL : IRepository<Brand>
    {
        private ProductContext dataBase;

        public BrandRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<Brand> GetList()
        {
            return dataBase.Brands.ToList();
        }

        public Brand GetItem(int id)
        {
            return dataBase.Brands.Find(id);
        }

        public void Create(Brand item)
        {
            dataBase.Brands.Add(item);
        }

        public void Update(Brand item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Brand item = dataBase.Brands.Find(id);
            if (item != null)
            {
                dataBase.Brands.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}
