﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<Category> Categories { get; }
        IReportsRepository Reports { get; }
        IRepository<OrderLines> OrderLines { get; }
        //ICatalogFiltersRepository CatalogFilters { get; }
        IServiceRepository Services { get; }
        IRepository<User> Users { get; }
        IRepository<Sale> Sales { get; }
        IRepository<User_Sale> UserSales { get; }
        int Save();
    }
}