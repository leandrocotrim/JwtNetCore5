using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace ServiceTest.PasswordValidatorSrv
{
    public class Password_Validator
    {
        private Service.PasswordValidatorSrv passwordValidatorSrv = new Service.PasswordValidatorSrv();

        [Theory]
        [InlineData("jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-", true)]
        [InlineData("k86Js3m-hpF2_79euU024!avUF&G!tDk", true)]
        [InlineData("R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z", true)]
        [InlineData("saDFGfas34D7777FG543dfd", false)]
        [InlineData("dfgdfgfdgfdgfdgdfg", false)]
        [InlineData("GSDFGDFGSDFGDSFGDFSG", false)]
        [InlineData("3b5-D#pT3", false)]
        public void Passwords_Valid(string password, bool valid)
        {
            var result = passwordValidatorSrv.Validate(new CrossCutting.DTOs.PasswordRequest { Password = password });

            Assert.True(result.IsValid == valid);
        }

        [Theory]
        [InlineData("saf43WEDFG5asdfd#", true)]
        [InlineData("aWSDFGHda345das@", true)]
        [InlineData("&sd345fsdfDFG435ds", true)]
        [InlineData("saDFGfas34DFG543dfd", false)]
        [InlineData("adaFG43daFGs34543", false)]
        [InlineData("345sFDGdf345sdfGds", false)]
        public void Has_Special_Character(string password, bool has)
        {
            var hasSpecialCharacter = passwordValidatorSrv.GetType()
                .GetMethod("HasSpecialCharacter", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (bool)hasSpecialCharacter.Invoke(passwordValidatorSrv, new object[] { password });

            Assert.True(result == has);
        }

        [Theory]
        [InlineData("saf43WEDFG5asdfd#1111", false)]
        [InlineData("2222aWSDFGHda345das@", false)]
        [InlineData("&sd345fsd8888fDFG435ds", false)]
        [InlineData("saDFGfas34DFG543dfd", true)]
        [InlineData("adaFG43daFGs34543", true)]
        [InlineData("345sFDGdf345sdfGds", true)]
        public void No_Sequence(string password, bool has)
        {
            var noSequence = passwordValidatorSrv.GetType()
                .GetMethod("NoSequence", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (bool)noSequence.Invoke(passwordValidatorSrv, new object[] { password });

            Assert.True(result == has);
        }
    }
}
