using Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IUserDetails
    {
        Task<dynamic> GetAllUserDetails();
        Task<dynamic> GetUserDetailsById(long id);
        Task<dynamic> SaveUserDetails(Userdetails userDetails);
        Task<dynamic> UpdateUserDetails(Userdetails userDetails);
        Task<dynamic> DeleteUserDetails(Userdetails userDetails);
        
    }

}
