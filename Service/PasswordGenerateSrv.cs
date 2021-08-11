using CrossCutting.DTOs;
using CrossCutting.Interfaces.Services;
using CrossCutting.ValueObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PasswordGenerateSrv : IPasswordGenerateSrv
    {
        private IValidator<PasswordRequest> passwordSrv;

        public PasswordGenerateSrv(IValidator<PasswordRequest> passwordSrv)
        {
            this.passwordSrv = passwordSrv;
        }

        public Task<string> Generate()
        {
            var numCaracteres = new Random().Next(15, 50);

            var strMask = RandomMask(numCaracteres);

            var password = string.Join(string.Empty, strMask.Select(RandomPassword));
            
            var result = passwordSrv.Validate(new PasswordRequest { Password = password }).IsValid ? 
                password : Generate().Result;

            return Task.FromResult(result);
        }

        private char RandomPassword(char _)
        {
            var listCaracteres = GetListCaracteres();

            var caracteres = listCaracteres[new Random().Next(0, listCaracteres.Count)];

            return caracteres[new Random().Next(0, caracteres.Length)];
        }

        private string RandomMask(int numCaracteres)
        {
            StringBuilder str = new StringBuilder();
            for (var i = 0; i < numCaracteres; i++) str.Append(" ");
            return str.ToString();
        }

        private List<string> GetListCaracteres()
        {
            return new List<string> {
                PasswordVO.CAPITAL_LETTERS,
                PasswordVO.NUMBERS,
                PasswordVO.SMALL_LETTERS,
                PasswordVO.SPECIAL_CHARACTERS
            };
        }
    }
}
