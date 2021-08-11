using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.AuthController.Helpers
{
    public class BuildAuthController
    {
        private Service.PasswordValidatorSrv passwordValidatorSrv = new Service.PasswordValidatorSrv();
        private Service.PasswordGenerateSrv passwordGenerateSrv;

        public BuildAuthController()
        {
            passwordGenerateSrv = new Service.PasswordGenerateSrv(passwordValidatorSrv);
        }

        public WebApi.Controllers.AuthController Build()
        {
            return new WebApi.Controllers.AuthController(
                  new Data.Repositories.UserRep(),
                  new Service.TokenSrv(),
                  passwordValidatorSrv,
                  passwordGenerateSrv
              );
        }
    }
}
