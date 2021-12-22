using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class CategoryTypeRepositorySQL : IRepository<CategoryType>
    {
        private ProductContext dataBase;

        public CategoryTypeRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<CategoryType> GetList()
        {
            return dataBase.CategoryType.ToList();
        }

        public CategoryType GetItem(int id)
        {
            return dataBase.CategoryType.Find(id);
        }

        public void Create(CategoryType item)
        {
            dataBase.CategoryType.Add(item);
        }

        public void Update(CategoryType item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CategoryType item = dataBase.CategoryType.Find(id);
            if (item != null)
            {
                dataBase.CategoryType.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}
