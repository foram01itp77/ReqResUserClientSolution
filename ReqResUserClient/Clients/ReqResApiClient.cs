using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ReqResUserClient.Configuration;
using ReqResUserClient.Models;
using ReqResUserClient.Exceptions; // You’ll create this

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
            try
            {
                var url = $"{_baseUrl}/users?page={page}";
                var response = await _httpClient.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new NotFoundException("Users not found for the given page.");

                response.EnsureSuccessStatusCode();

                var users = await response.Content.ReadFromJsonAsync<UserResponse>();
                return users;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Network error occurred while fetching users.", ex);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (JsonException ex)
            {
                throw new ApplicationException("Error parsing user list response.", ex);
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                var url = $"{_baseUrl}/users/{userId}";
                var response = await _httpClient.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new NotFoundException($"User with ID {userId} not found.");

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, UserDto>>();
                return result != null && result.ContainsKey("data") ? result["data"] : null;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Network error occurred while fetching the user.", ex);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (JsonException ex)
            {
                throw new ApplicationException("Error parsing user detail response.", ex);
            }
        }
    }
}
