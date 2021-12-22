using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private ProductContext db;
        private ProductRepositorySQL ProductRepository;
        private OrderRepositorySQL OrderRepository;
        private CategoryRepositorySQL CategoryRepository;
        private OrderLinesRepositorySQL OrderLinesRepository;
        private ReportRepositorySQL ReportRepository;
        private SaleRepositorySQL saleRepositorySQL;
        private UserSaleRepositorySQL userSaleRepositorySQL;
        private ServiceRepositorySQL serviceRepositorySQL;
        private BuyerRepositorySQL buyerRepositorySQL;
        private ShoppingCartRepositorySQL shoppingCartRepositorySQL;
        //private BatchOfBatchOfProductRepositorySQL batchOfProductRepositorySQL;
        public DbReposSQL()
        {
            db = new ProductContext();
        }

        public IRepository<Product> Products
        {
            get
            {
                if (ProductRepository == null)
                    ProductRepository = new ProductRepositorySQL(db);
                return ProductRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (OrderRepository == null)
                    OrderRepository = new OrderRepositorySQL(db);
                return OrderRepository;
            }
        }

        public IRepository<ShoppingCart> ShoppingCarts
        {
            get
            {
                if (shoppingCartRepositorySQL == null)
                    shoppingCartRepositorySQL = new ShoppingCartRepositorySQL(db);
                return shoppingCartRepositorySQL;
            }
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (CategoryRepository == null)
                    CategoryRepository = new CategoryRepositorySQL(db);
                return CategoryRepository;
            }
        }
        public IRepository<OrderLines> OrderLines
        {
            get
            {
                if (OrderLinesRepository == null)
                    OrderLinesRepository = new OrderLinesRepositorySQL(db);
                return OrderLinesRepository;
            }
        }
        public IReportsRepository Reports
        {
            get
            {
                if (ReportRepository == null)
                    ReportRepository = new ReportRepositorySQL(db);
                return ReportRepository;
            }
        }
        
        public IRepository<Sale> Sales
        {
            get
            {
                if (saleRepositorySQL == null)
                    saleRepositorySQL = new SaleRepositorySQL(db);
                return saleRepositorySQL;
            }
        }

        public IRepository<User_Sale> UserSales
        {
            get
            {
                if (userSaleRepositorySQL == null)
                    userSaleRepositorySQL = new UserSaleRepositorySQL(db);
                return userSaleRepositorySQL;
            }
        }

        public IServiceRepository Services
        {
            get
            {
                if (serviceRepositorySQL == null)
                    serviceRepositorySQL = new ServiceRepositorySQL(db);
                return serviceRepositorySQL;
            }
        }

        public IRepository<Buyer> Buyers
        {
            get
            {
                if (buyerRepositorySQL == null)
                    buyerRepositorySQL = new BuyerRepositorySQL(db);
                return buyerRepositorySQL;
            }
        }

        public int Save()
        {
            
            return db.SaveChanges();
        }
    }
}
