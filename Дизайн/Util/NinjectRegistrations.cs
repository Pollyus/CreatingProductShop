using BBL.Interfaces;
using Ninject.Modules;
using BAL;
using BAL.Interfaces;
using BBL.Servises;
using BAL.Servises;
using BBL;

namespace View.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DbDataOperation>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ICatalogService>().To<ProductCatalogService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IProfileService>().To<ProfileService>();
        }
    }
}
