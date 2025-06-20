using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
//using ReqResUserClient.Clients;
using ReqResUserClient.Models;
using ReqResUserClient.Services;
using ReqResUserClient;

namespace Tests
{
    

    public class ExternalUserServiceTests
    {
        [Fact]
        public async Task GetAllUsersAsync_ReturnsUsers()
        {
            var mockClient = new Mock<ReqResApiClient>(null, null);
            mockClient.SetupSequence(c => c.GetUsersByPageAsync(It.IsAny<int>()))
                      .ReturnsAsync(new UserResponse
                      {
                          Total_Pages = 1,
                          Data = new List<UserDto> { new UserDto { Id = 1, First_Name = "Test" } }
                      });

            var service = new ExternalUserService(mockClient.Object);

            var users = await service.GetAllUsersAsync();

            Assert.Single(users);
        }

    }

}
