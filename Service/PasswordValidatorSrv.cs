using CrossCutting.Interfaces.Services;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CrossCutting.DTOs;
using CrossCutting.ValueObjects;

namespace Service
{
    public class PasswordValidatorSrv : AbstractValidator<PasswordRequest>//, IPasswordSrv
    {
        public PasswordValidatorSrv()
        {
            RuleFor(p => p.Password).NotNull();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(15);
            RuleFor(p => p.Password).Matches("[a-z]");
            RuleFor(p => p.Password).Matches("[A-Z]");
            RuleFor(p => p.Password).Must(HasSpecialCharacter);
            RuleFor(p => p.Password).Must(NoSequence);
        }

        private bool HasSpecialCharacter(string password)
        {            
            return PasswordVO.SPECIAL_CHARACTERS.Any(sChar => password.Contains(sChar));
        }

        private bool NoSequence(string password)
        {
            for (var i = 0; i < password.Length; i++)
            {
                if (i + 4 > password.Length) break;

                var referer = password[i].ToString();
                if (password.Substring(i, 4) == (referer + referer + referer + referer))
                    return false;
            }

            return true;
        }
    }
}
