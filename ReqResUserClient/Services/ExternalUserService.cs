using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResUserClient.Services
{
    using ReqResUserClient.Interfaces;
    using ReqResUserClient.Models;

    public class ExternalUserService : IExternalUserService
    {
        private readonly ReqResApiClient _client;

        public ExternalUserService(ReqResApiClient client)
        {
            _client = client;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            return await _client.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = new List<UserDto>();
            int page = 1;

            while (true)
            {
                var result = await _client.GetUsersByPageAsync(page);
                if (result?.Data == null || result.Data.Count == 0) break;

                users.AddRange(result.Data);
                if (page >= result.Total_Pages) break;
                page++;
            }

            return users;
        }
    }

}
