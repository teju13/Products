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
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _iorder;
        public OrdersController(IOrders iorder)
        {
            _iorder = iorder;
        }

        /// <summary>
        /// To get all Orders Record from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllOrders")]
        public async Task<DataResult<dynamic>> GetAllOrders()
        {
            try
            {
                var customerData = await _iorder.GetAllOrders();


                if (customerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, customerData);
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
        /// To get the OrdersDetails record by Id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetOrderDetailsById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetOrderDetailsById(int id)
        {
            try
            {
                var orderData = await _iorder.GetOrderDetailsById(id);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
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
        /// To save the Orderdetails in DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        [HttpPost("SaveOrderDetails")]
        public async Task<DataResult<dynamic>> SaveOrderDetails([FromBody] Orders order)
        {
            try
            {
                var orderData = await _iorder.SaveOrderDetails(order);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
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
        /// Updating the existing details of Orders in DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("UpdateOrderDetails")]

        public async Task<DataResult<dynamic>> UpdateOrderDetails([FromBody] Orders order)
        {
            try
            {
                var orderData = await _iorder.UpdateOrderDetails(order);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
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
        /// To Delete the Orders record in DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpDelete("DeleteOrderDetails")]
        public async Task<DataResult<dynamic>> DeleteOrderDetails([FromBody] Orders order)
        {
            try
            {
                var orderData = await _iorder.DeleteOrderDetails(order);


                if (orderData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, orderData);
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
