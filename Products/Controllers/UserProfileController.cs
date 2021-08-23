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
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfile _iuserprofile;
        public UserProfileController(IUserProfile iuserprofile)
        {
            _iuserprofile = iuserprofile;
        }

        /// <summary>
        /// To get all UserProfile records from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUserProfiles")]
        
        public async Task<DataResult<dynamic>> GetAllUserProfiles()
        {
            try
            {
                var UserProfileData = await _iuserprofile.GetAllUserProfiles();


                if (UserProfileData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserProfileData);
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
        /// To get UserProfile records by Id from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserProfileById/{​​​​​​​id}​​​​​​​")]
        public async Task<DataResult<dynamic>> GetUserProfileById(int id)
        {
            try
            {
                var UserProfileData = await _iuserprofile.GetUserProfileById(id);


                if (UserProfileData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserProfileData);
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
        /// To save the UserProfile record in DB
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        [HttpPost("SaveUserProfile")]
        public async Task<DataResult<dynamic>> SaveUserProfile([FromBody] UserProfile userProfile)
        {
            try
            {
                var UserProfileData = await _iuserprofile.SaveUserProfile(userProfile);


                if (UserProfileData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserProfileData);
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
        /// Updating the existing UserProfile record in DB
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserProfile")]

        public async Task<DataResult<dynamic>> UpdateUserProfile([FromBody] UserProfile userProfile)
        {
            try
            {
                var UserProfileData = await _iuserprofile.UpdateUserProfile(userProfile);


                if (UserProfileData != null)
                {
                    return new DataResult<dynamic>(StatusCodes.Status200OK, UserProfileData);
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
        /// To Delete the UserProfile record in DB
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserProfile/{id}")]
        public async Task<DataResult<dynamic>> DeleteUserProfile(int id)
        {
            try
            {
                UserProfile obj = new UserProfile()
                {
                    UserProfileId = id
                };



                var customerData = await _iuserprofile.DeleteUserProfile(obj);



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
                return new DataResult<dynamic>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
    }
