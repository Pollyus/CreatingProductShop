using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    //public class ProductTypeRepositorySQL : IRepository<ProductType>
    //{
    //    private MusicShop dataBase;

    //    public ProductTypeRepositorySQL(MusicShop dbcontext)
    //    {
    //        this.dataBase = dbcontext;
    //    }
    //    public List<Product_Type> GetList()
    //    {
    //        return dataBase.Product_Types.ToList();
    //    }

    //    public Product_Type GetItem(int id)
    //    {
    //        return dataBase.Product_Types.Find(id);
    //    }

    //    public void Create(Product_Type item)
    //    {
    //        dataBase.Product_Types.Add(item);
    //    }

    //    public void Update(Product_Type item)
    //    {
    //        dataBase.Entry(item).State = EntityState.Modified;
    //    }

    //    public void Delete(int id)
    //    {
    //        Product_Type item = dataBase.Product_Types.Find(id);
    //        if (item != null)
    //        {
    //            dataBase.Product_Types.Remove(item);
    //        }
    //    }

    //    public bool Save()
    //    {
    //        return dataBase.SaveChanges() > 0;
    //    }
    //}
}
