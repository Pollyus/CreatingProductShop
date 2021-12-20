using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class UserRepositorySQL : IRepository<User>
    {
        private ProductContext dataBase;

        public UserRepositorySQL(ProductContext dbcontext)
        {
            this.dataBase = dbcontext;
        }
        public List<User> GetList()
        {
            return dataBase.Users.ToList();
        }

        public User GetItem(int id)
        {
            return dataBase.Users.Find(id);
        }

        public void Create(User item)
        {
            item.TipeID = 1;
            dataBase.Users.Add(item);
        }

        public void Update(User item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User item = dataBase.Users.Find(id);
            if (item != null)
            {
                dataBase.Users.Remove(item);
            }
        }

        public bool Save()
        {
            return dataBase.SaveChanges() > 0;
        }
    }
}
