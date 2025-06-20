using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqResUserClient.Models;
namespace ReqResUserClient.Interfaces
{
    

    public interface IExternalUserService
    {
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }

}
