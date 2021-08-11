using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest.AuthController
{
    public class Password_IsValid_Post
    {
        private WebApi.Controllers.AuthController authController;

        public Password_IsValid_Post()
        {
            this.authController = new Helpers.BuildAuthController().Build();
        }

        [Theory]
        [InlineData("jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-")]
        [InlineData("k86Js3m-hpF2_79euU024!avUF&G!tDk")]
        [InlineData("R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z")]
        public void Password_IsValid_True(string password)
        {
            var action = authController.Post(new CrossCutting.DTOs.PasswordRequest {  Password = password }).Result;
            var result = action.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)result.Value);
            
        }

        [Theory]
        [InlineData("jS&3b")]
        [InlineData("k86Js3m-hpF29999_79euU024!avUF&G!tDk")]
        [InlineData("R9D#677987979797")]
        public void Password_IsValid_False(string password)
        {
            var action = authController.Post(new CrossCutting.DTOs.PasswordRequest { Password = password }).Result;
            var result = action.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.False((bool)result.Value);            
        }
    }
}
