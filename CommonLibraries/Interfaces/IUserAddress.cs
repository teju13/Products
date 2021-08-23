using Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraries.Interfaces
{
    public interface IUserAddress
    {
        Task<dynamic> GetAllUserAddress();
        Task<dynamic> GetUserAddressById(long id);
        Task<dynamic> SaveUserAddress(UserAddress userAddress);
        Task<dynamic> UpdateUserAddress(UserAddress userAddress);
        Task<dynamic> DeleteUserAddress(UserAddress userAddress);

    }

}
