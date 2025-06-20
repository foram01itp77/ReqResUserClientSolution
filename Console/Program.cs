// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;

//Console.WriteLine("Hello, World!");
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using ReqResUserClient.Configuration;
using ReqResUserClient.Extensions;
using ReqResUserClient.Interfaces;

var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: false);
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<ReqResOptions>(context.Configuration.GetSection("ReqRes"));
        services.AddReqResClient();
    })
    .Build();

var service = host.Services.GetRequiredService<IExternalUserService>();

Console.WriteLine("Fetching all users...");
var users = await service.GetAllUsersAsync();
foreach (var user in users)
    Console.WriteLine($"{user.Id}: {user.First_Name} {user.Last_Name}");

Console.WriteLine("Fetching user ID 2...");
var user2 = await service.GetUserByIdAsync(2);
Console.WriteLine($"{user2.Id}: {user2.First_Name} {user2.Last_Name}");
