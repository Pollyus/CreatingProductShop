using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class ProductRepositorySQL : IRepository<Product>
    {
        private ProductContext db;

        public ProductRepositorySQL(ProductContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Product> GetList()
        {
            return db.Product.ToList();
        }

        public Product GetItem(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product product)
        {
            product.Id = 10;
            db.Product.Add(product);

        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product product = db.Product.Find(id);
            if (product != null)
                db.Product.Remove(product);
        }
    }
}
