using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataTest.Repositories.UserRep
{
    public class Get_User
    {
        [Theory]
        [InlineData("Leandro", "jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-")]
        [InlineData("Macedo", "k86Js3m-hpF2_79euU024!avUF&G!tDk")]
        [InlineData("Cotrim", "R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z")]
        public void Get_User_By_Username_Password_Ok(string username, string password)
        {
            var user = new Data.Repositories.UserRep().Get(
                new CrossCutting.DTOs.UserRequest { Username = username, Password = password }
            );

            Assert.NotNull(user.Result);
        }

        [Theory]
        [InlineData("Leandro", "_jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-")]
        [InlineData("Macedo", "_k86Js3m-hpF2_79euU024!avUF&G!tDk")]
        [InlineData("Cotrim", "_R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z")]
        public void Get_User_By_Username_Password_Null(string username, string password)
        {
            var user = new Data.Repositories.UserRep().Get(
                new CrossCutting.DTOs.UserRequest { Username = username, Password = password }
            );

            Assert.Null(user.Result);
        }
    }
}
