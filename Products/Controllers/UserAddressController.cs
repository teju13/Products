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
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddress _iUserAddress;
        public UserAddressController(IUserAddress iUserAddress)
        {
            _iUserAddress = iUserAddress;
        }

        /// <summary>
        /// To get all UserAddress List from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUserAddress")]
        public async Task<DataResult<dynamic>> GetAllUserAddress()
        {
            try
            {
                var UserAddressData = await _iUserAddress.GetAllUserAddress();


                if (UserAddressData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserAddressData);
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
        /// To get UserAddress records by Id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserAddressById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetUserAddressById(int id)
        {
            try
            {
                var UserAddressData = await _iUserAddress.GetUserAddressById(id);


                if (UserAddressData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserAddressData);
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
        /// To save the UserAddress record in DB
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        [HttpPost("SaveUserAddress")]
        public async Task<DataResult<dynamic>> SaveUserAddress([FromBody] UserAddress userAddress)
        {
            try
            {
                var UserAddressData = await _iUserAddress.SaveUserAddress(userAddress);


                if (UserAddressData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserAddressData);
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
        /// Updating the existing UserAddress record in DB
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserAddress")]

        public async Task<DataResult<dynamic>> UpdateUserAddress([FromBody] UserAddress userAddress)
        {
            try
            {
                var UserAddressData = await _iUserAddress.UpdateUserAddress(userAddress);


                if (UserAddressData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserAddressData);
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
        /// To Delete the UserAddress record in DB
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserAddress")]
        public async Task<DataResult<dynamic>> DeleteUserAddress([FromBody] UserAddress userAddress)
        {
            try
            {
                var UserAddressData = await _iUserAddress.DeleteUserAddress(userAddress);


                if (UserAddressData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserAddressData);
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

