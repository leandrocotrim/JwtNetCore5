using CrossCutting.DTOs;
using CrossCutting.Interfaces.Repositories;
using CrossCutting.Interfaces.Services;
using Data.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureServices((_, services) => services
                .AddSingleton<IUserRep, UserRep>()
                .AddSingleton<ITokenSrv, TokenSrv>()
                .AddSingleton<IValidator<PasswordRequest>, PasswordValidatorSrv>()
                .AddSingleton<IPasswordGenerateSrv, PasswordGenerateSrv>()
            );
            
    }
}
