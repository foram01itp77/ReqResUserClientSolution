using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ReqResUserClient.Configuration;
using ReqResUserClient.Interfaces;
using ReqResUserClient.Services;
using Polly.Extensions.Http;



namespace ReqResUserClient.Extensions
{
    
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReqResClient(this IServiceCollection services)
        {
             services.AddHttpClient<ReqResApiClient>();
     //       services.AddHttpClient<ReqResApiClient>()
     //.AddTransientHttpErrorPolicy(policy =>
     //    policy.WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry))));

            services.AddScoped<IExternalUserService, ExternalUserService>();
            return services;
        }
    }

}
