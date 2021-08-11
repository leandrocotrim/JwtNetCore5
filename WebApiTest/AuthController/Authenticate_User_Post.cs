using CrossCutting.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.AuthController
{
    public class Authenticate_User_Post
    {
        [Theory]
        [InlineData("Leandro", "jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-")]
        [InlineData("Macedo", "k86Js3m-hpF2_79euU024!avUF&G!tDk")]
        [InlineData("Cotrim", "R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z")]
        public void Authentication_Ok(string username, string password)
        {
            var authController = new Helpers.BuildAuthController().Build();
            var action = authController.Post(new CrossCutting.DTOs.UserRequest { Username = username, Password = password }).Result;
            
            var result = action.Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);

            var userResponse = result.Value as UserResponse;
            Assert.NotNull(userResponse.Token);
        }

        [Theory]
        [InlineData("Leandro", "*jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-")]
        [InlineData("Macedo", "*k86Js3m-hpF2_79euU024!avUF&G!tDk")]
        [InlineData("Cotrim", "*R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z")]
        public void Authentication_NotFound(string username, string password)
        {
            var authController = new Helpers.BuildAuthController().Build();
            var action = authController.Post(new CrossCutting.DTOs.UserRequest { Username = username, Password = password }).Result;
            
            var result = action.Result as NotFoundObjectResult;
            Assert.IsType<NotFoundObjectResult>(result);

            var userResponse = result.Value as UserResponse;
            Assert.Null(userResponse);
        }
    }
}
