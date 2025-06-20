using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using ReqResUserClient.Configuration;
using ReqResUserClient.Models;

namespace ReqResUserClient
{




    public class ReqResApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ReqResApiClient(HttpClient httpClient, IOptions<ReqResOptions> options)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
        }

        public async Task<UserResponse> GetUsersByPageAsync(int page)
        {
            var url = $"{_baseUrl}/users?page={page}";
            return await _httpClient.GetFromJsonAsync<UserResponse>(url);
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var result = await _httpClient.GetFromJsonAsync<Dictionary<string, UserDto>>($"{_baseUrl}/users/{userId}");
            return result != null && result.ContainsKey("data") ? result["data"] : null;
        }
    }


}
