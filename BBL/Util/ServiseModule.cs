using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repository;
using Ninject.Modules;

namespace BAL.Util
{
    public class ServiceModule : NinjectModule
    {
        //private string connectionString;
        public ServiceModule()//(string connection)
        {
            //connectionString = connection;
        }
        public override void Load()
        {
            Bind<IDbRepos>().To<DbReposSQL>().InSingletonScope();//.WithConstructorArgument(connectionString);
        }
    }
}