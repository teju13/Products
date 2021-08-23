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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomers _icustomer;
        public CustomerController(ICustomers icustomer)
        {
            _icustomer = icustomer;
        }

        /// <summary>
        /// To get all Customers records in Swagger from DB
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllCustomers")]
        public async Task<DataResult<dynamic>> GetAllCustomers()
        {
            try
            {
                var customerData = await _icustomer.GetAllCustomers();


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
        /// To get CustomerDetails by Id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCustomerDetailsById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetCustomerDetailsById(int id)
        {
            try
            {
                var customerData = await _icustomer.GetCustomerDetailsById(id);


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
        /// To save the CustomerDetails record in DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("SaveCustomerDetails")]
        public async Task<DataResult<dynamic>> SaveCustomerDetails([FromBody] Customers customer)
        {
            try
            {
                var customerData = await _icustomer.SaveCustomerDetails(customer);


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
        /// Updating the existing CustomerDetails in DB 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("UpdateCustomerDetails")]

        public async Task<DataResult<dynamic>> UpdateCustomerDetails([FromBody] Customers customer)
        {
            try
            {
                var customerData = await _icustomer.UpdateCustomerDetails(customer);


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
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "ex.Message");
            }
        }

        /// <summary>
        /// To Delete the one of the Customer record in DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>

        [HttpDelete("DeleteCustomerDetails")]
        public async Task<DataResult<dynamic>> DeleteCustomerDetails([FromBody] Customers customer)
        {
            try
            {
                var customerData = await _icustomer.DeleteCustomerDetails(customer);


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
    }
}













