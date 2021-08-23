using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.DBContext;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataUoW _dataUow;
        private readonly DataContext _dataContext;
        public ProductsController(IDataUoW dataUow, DataContext dataContext)
        {
            _dataUow = dataUow;
            _dataContext = dataContext;
        }


       /// <summary>
       /// here we get the userprofile list from the database
       /// </summary>
       /// <returns></returns>
        //User Profile Table
        [HttpGet("GetUserProfileList")]
        public async Task<dynamic> GetUserProfileList()
        {
            try 
            {
                var providerData = await _dataUow.UserProfile.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }


        /// <summary>
        /// To get the userprofile by ID from database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetUserProfileById/{id}")]
        public async Task<DataResult<dynamic>> GetUserProfileById(int id, string fname)
        {
            try
            {
                if (id <= 0)
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.UserProfile.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        /// <summary>
        /// to save the userprofile record in DB
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost("SaveUserProfile")]
        public async Task<dynamic> SaveUserProfile(UserProfile profile)
        {
            try
            {
                _dataUow.UserProfile.Add(profile);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }


        /// <summary>
        /// To update the userprofile record in DB
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserProfile")]
        public async Task<dynamic> UpdateUserProfile(UserProfile profile)
        {
            try
            {
                _dataUow.UserProfile.Update(profile);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// To delete the userprofile record of existing data in DB 
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserProfile")]
        public async Task<dynamic> DeleteUserProfile(UserProfile profile)
        {
            try
            {
                _dataUow.UserProfile.Delete(profile);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// Here we get the secretquestionlist data from DB
        /// </summary>
        /// <returns></returns>

        //Secret Question Table
        [HttpGet("GetSecretQuestionList")]
        public async Task<dynamic> GetSecretQuestionList()
        {
            try
            {
                var providerData = await _dataUow.SecretQuestions.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// To get the secretquestion table by Id from Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetSecretQuestionsById/{id}")]
        public async Task<DataResult<dynamic>> GetSecretQuestionsById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.SecretQuestions.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        /// <summary>
        /// To save the given secretquestion record in Database
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost("SaveSecretQuestion")]
        public async Task<dynamic> SaveSecretQuestion(SecretQuestions question)
        {
            try
            {
                _dataUow.SecretQuestions.Add(question);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Updating the secretquestion record of existing data in DB
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPut("UpdateSecretQuestion")]
        public async Task<dynamic> UpdateSecretQuestion(SecretQuestions question)
        {
            try
            {
                _dataUow.SecretQuestions.Update(question);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// To Delete the secretquestion record in DB
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>

        [HttpDelete("DeleteSecretQuestion")]
        public async Task<dynamic> DeleteSecretQuestion(SecretQuestions question)
        {
            try
            {
                _dataUow.SecretQuestions.Delete(question);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get the List of userdetails from DB
        /// </summary>
        /// <returns></returns>
        //User details Table
        [HttpGet("GetUserdetailsList")]
        public async Task<dynamic> GetUserdetailsList()
        {
            try
            {
                var providerData = await _dataUow.Userdetails.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
         /// <summary>
        /// we get userdetailsdata by ID from DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetUserDetailsById/{id}")]
        public async Task<DataResult<dynamic>> GetUserDetailsById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Userdetails.GetAllWithNoTracking().Where(p => p.UserDetailsId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        /// <summary>
        /// To save the userdetails record from swagger to DB
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [HttpPost("SaveUserdetails")]
        public async Task<dynamic> SaveUserdetails(Userdetails details)
        {
            try
            {
                _dataUow.Userdetails.Add(details);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// Updating the userdetails record of existing data in DB
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>

        [HttpPut("UpdateUserdetails")]
        public async Task<dynamic> UpdateUserdetails(Userdetails details)
        {
            try
            {
                _dataUow.Userdetails.Update(details);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        /// <summary>
        /// Delete the userdetails record in DB
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserdetails")]
        public async Task<dynamic> DeleteUserdetails(Userdetails details)
        {
            try
            {
                _dataUow.Userdetails.Delete(details);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }


        /// <summary>
        /// To get the list of UserAddress records from DB
        /// </summary>
        /// <returns></returns>

        //User Address Table
        [HttpGet("GetUserAddressList")]
        public async Task<dynamic> GetUserAddressList()
        {
            try
            {
                var providerData = await _dataUow.UserAddress.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get the UserAddress record by Id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetUserAddressById/{id}")]
        public async Task<DataResult<dynamic>> GetUserAddressById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.UserAddress.GetAllWithNoTracking().Where(p => p.UserProfileId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        /// <summary>
        /// To save the UserAddress record from swagger in DB
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("SaveUserAddress")]
        public async Task<dynamic> SaveUserAddress(UserAddress address)
        {
            try
            {
                _dataUow.UserAddress.Add(address);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Upating the UserAddress record of existing table in DB from Swagger
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserAddress")]
        public async Task<dynamic> UpdateUserAddress(UserAddress address)
        {
            try
            {
                _dataUow.UserAddress.Update(address);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To delete the existing UserAddress record  in DB
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserAddress")]
        public async Task<dynamic> DeleteUserAddress(UserAddress address)
        {
            try
            {
                _dataUow.UserAddress.Delete(address);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get the Product Table List from DB
        /// </summary>
        /// <returns></returns>
        //Product Table
        [HttpGet("GetProductList")]
        public async Task<dynamic> GetProductList()
        {
            try
            {
                var providerData = await _dataUow.Product.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// To get the product record by Id in swagger
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetProductsById/{id}")]
        public async Task<DataResult<dynamic>> GetProductsById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Product.GetAllWithNoTracking().Where(p => p.ProductId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
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
        [HttpPost("SaveProduct")]
        public async Task<dynamic> SaveProduct(Product product)
        {
            try
            {
                _dataUow.Product.Add(product);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Upating one of the records in existing ProductTable in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("UpdateProduct")]
        public async Task<dynamic> UpdateProduct(Product product)
        {
            try
            {
                _dataUow.Product.Update(product);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// To delete one of the Product records in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        [HttpDelete("DeleteProduct")]
        public async Task<dynamic> DeleteProduct(Product product)
        {
            try
            {
                _dataUow.Product.Delete(product);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get the CustomerList from DB
        /// </summary>
        /// <returns></returns>
        //Customers Table
        [HttpGet("GetCustomersList")]
        public async Task<dynamic> GetCustomersList()
        {
            try
            {
                var providerData = await _dataUow.Customers.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get the customers record by ID From DB in output
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetCustomersById/{id}")]
        public async Task<DataResult<dynamic>> GetCustomersById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Customers.GetAllWithNoTracking().Where(p => p.CustomerId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        /// <summary>
        /// To save the customers record in DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("SaveCustomers")]
        public async Task<dynamic> SaveCustomers(Customers customer)
        {
            try
            {
                _dataUow.Customers.Add(customer);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Updating the customers record of Existing date in DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("UpdateCustomers")]
        public async Task<dynamic> UpdateCustomers(Customers customer)
        {
            try
            {
                _dataUow.Customers.Update(customer);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Delete Customers record in DB
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCustomers")]
        public async Task<dynamic> DeleteCustomers(Customers customer)
        {
            try
            {
                _dataUow.Customers.Delete(customer);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get the List of Orders Table from DB
        /// </summary>
        /// <returns></returns>
        //Order Table
        [HttpGet("GetOrdersList")]
        public async Task<dynamic> GetOrdersList()
        {
            try
            {
                var providerData = await _dataUow.Orders.GetAll().ToListAsync();
                return providerData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// To get Orders record by ID from DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>
        /// <returns></returns>
        [HttpGet("GetOrdersById/{id}")]
        public async Task<DataResult<dynamic>> GetOrdersById(int id, string fname)
        {
            try
            {
                if (id <= 0 || string.IsNullOrEmpty(fname))
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, null, new ValidationResultModel() { Message = "Id must not be less than 0" });
                }
                var providerData = await _dataUow.Orders.GetAllWithNoTracking().Where(p => p.OrderId == id).FirstOrDefaultAsync();

                if (providerData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, providerData);
                }
                else
                {
                    return new DataResult<dynamic>(StatusCodes.Status412PreconditionFailed, "Entered data does not match our records. Please try again.");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, "Internal exception");
            }
        }


        /// <summary>
        /// To save the Orders record in DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("SaveOrders")]
        public async Task<dynamic> SaveOrders(Orders order)
        {
            try
            {
                _dataUow.Orders.Add(order);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Updating the existing Orders record in DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("UpdateOrders")]
        public async Task<dynamic> UpdateOrders(Orders order)
        {
            try
            {
                _dataUow.Orders.Update(order);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        /// <summary>
        /// To Delete the Orders record in DB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpDelete("DeleteOrders")]
        public async Task<dynamic> DeleteOrders(Orders order)
        {
            try
            {
                _dataUow.Orders.Delete(order);
                await _dataUow.CommitAsync("");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
