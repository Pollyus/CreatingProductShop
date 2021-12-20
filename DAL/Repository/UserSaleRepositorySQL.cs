using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class UserSaleRepositorySQL : IRepository<User_Sale>
    {
        private ProductContext dataBase;

        public UserSaleRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<User_Sale> GetList()
        {
            return dataBase.User_Sales.ToList();
        }

        public User_Sale GetItem(int id)
        {
            return dataBase.User_Sales.Find(id);
        }

        public void Create(User_Sale item)
        {
            dataBase.User_Sales.Add(item);
        }

        public void Update(User_Sale item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User_Sale item = dataBase.User_Sales.Find(id);
            if (item != null)
            {
                dataBase.User_Sales.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}
