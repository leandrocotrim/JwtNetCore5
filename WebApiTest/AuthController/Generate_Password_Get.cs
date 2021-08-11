using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.AuthController
{
    public class Generate_Password_Get
    {
        [Fact]
        public void Generate_Password()
        {
            var authController = new Helpers.BuildAuthController().Build();
            var action = authController.Get().Result;
            var result = action.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result.Value);
        }
    }
}
