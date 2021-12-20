using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Models;
using BLL.Models;

namespace BBL.Interfaces
{
    public interface ICatalogService
    {
        List<ProductModel> GetProductsByCategory(string category);
    }
}
