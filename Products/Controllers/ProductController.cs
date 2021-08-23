using CommonLibraries.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _iProduct;
        public ProductController(IProduct iProduct)
        {
            _iProduct = iProduct;
        }

        /// <summary>
        /// To get all Product records from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProducts")]
        public async Task<DataResult<dynamic>> GetAllProducts()
        {
            try
            {
                var ProductData = await _iProduct.GetAllProducts();


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        /// <summary>
        /// To get Product Details by ID from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetProductDetailsById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetProductDetailsById(int id)
        {
            try
            {
                var ProductData = await _iProduct.GetProductDetailsById(id);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        /// <summary>
        /// To save the Product record in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("SaveProductDetails")]
        public async Task<DataResult<dynamic>> SaveProductDetails([FromBody] Product product)
        {
            try
            {
                var ProductData = await _iProduct.SaveProductDetails(product);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }

        /// <summary>
        /// Updating the existing Product Details in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("UpdateProductDetails")]

        public async Task<DataResult<dynamic>> UpdateProductDetails([FromBody] Product product)
        {
            try
            {
                var ProductData = await _iProduct.UpdateProductDetails(product);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "ex.Message");
            }
        }

        /// <summary>
        /// To Delete the Product record in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpDelete("DeleteProductDetails")]
        public async Task<DataResult<dynamic>> DeleteProductDetails([FromBody] Product product)
        {
            try
            {
                var ProductData = await _iProduct.DeleteProductDetails(product);


                if (ProductData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, ProductData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "No records found.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }
    }
}

