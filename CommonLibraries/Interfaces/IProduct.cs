using Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IProduct
    {
        Task<dynamic> GetAllProducts();
        Task<dynamic> GetProductDetailsById(long id);
        Task<dynamic> SaveProductDetails(Product product);
        Task<dynamic> UpdateProductDetails(Product product);
        Task<dynamic> DeleteProductDetails(Product product);


    }

}
