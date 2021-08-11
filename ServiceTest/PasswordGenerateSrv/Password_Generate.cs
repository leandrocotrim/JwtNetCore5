using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace ServiceTest.PasswordGenerateSrv
{
    public class Password_Generate
    {
        private Service.PasswordValidatorSrv passwordValidatorSrv = new Service.PasswordValidatorSrv();
        private Service.PasswordGenerateSrv passwordGenerateSrv;

        public Password_Generate()
        {
            passwordGenerateSrv = new Service.PasswordGenerateSrv(passwordValidatorSrv);
        }

        [Fact]
        public void Generate()
        {
            var generatePassword = passwordGenerateSrv.Generate().Result;
            var passwordRequest = new CrossCutting.DTOs.PasswordRequest { Password = generatePassword };

            Assert.True(passwordValidatorSrv.Validate(passwordRequest).IsValid);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(25)]
        public void Random_Mask(int numCaracteres)
        {
            var randomMask = passwordGenerateSrv.GetType()
                .GetMethod("RandomMask", BindingFlags.NonPublic | BindingFlags.Instance);

            var passwordMask = randomMask.Invoke(passwordGenerateSrv, new object[] { numCaracteres }).ToString();

            Assert.True(passwordMask.Length == numCaracteres);
        }
    }
}
