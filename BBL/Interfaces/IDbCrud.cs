using BAL.Models;
using System.Collections.Generic;
using BBL.Interfaces;
using BLL.Models;
using BBL.Models;

namespace BAL.Interfaces
{
    public interface IDbCrud
    {
        List<ProductModel> GetAllProducts();
        //List<BatchOfProductModel> GetAllBatch();
        List<OrderModel> GetAllOrders();
        List<CategoryModel> GetAllCategories();
        List<OrderLineModel> GetAllOrderLines();
        ProductModel GetProduct(int productId);
        void CreateProduct(ProductModel product);
        void CreateBuyer(BuyerModel byuer);
        
        void UpdateProduct(ProductModel product);
        void DeleteProduct(int id);
        OrderModel GetOrder(int Id);
        void DeleteOrder(int id);
        void DeleteCart(int id);
        
        void CreateCart(CartModel cart);
        
        void UpdateCart(CartModel cart);
        bool Save();

    }
}
