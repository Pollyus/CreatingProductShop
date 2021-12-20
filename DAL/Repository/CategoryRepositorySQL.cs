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
    public class CategoryRepositorySQL : IRepository<Category>
    {
        private ProductContext db;
        public CategoryRepositorySQL(ProductContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Category> GetList()
        {
            return db.Category.ToList();
        }

        public Category GetItem(int id)
        {
            return db.Category.Find(id);
        }

        public void Create(Category item)
        {
            db.Category.Add(item);
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category item = db.Category.Find(id);
            if (item != null)
                db.Category.Remove(item);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
