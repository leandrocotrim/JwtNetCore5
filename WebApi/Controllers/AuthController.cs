using CrossCutting.DTOs;
using CrossCutting.Interfaces.Repositories;
using CrossCutting.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRep userRep;
        private readonly ITokenSrv tokenSrv;
        private readonly IValidator<PasswordRequest> passwordSrv;
        private readonly IPasswordGenerateSrv passwordGenerateSrv;

        public AuthController(
            IUserRep userRep, ITokenSrv tokenSrv, 
            IValidator<PasswordRequest> passwordSrv,
            IPasswordGenerateSrv passwordGenerateSrv)
        {
            this.userRep = userRep;
            this.tokenSrv = tokenSrv;
            this.passwordSrv = passwordSrv;
            this.passwordGenerateSrv = passwordGenerateSrv;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserResponse>> Post([FromBody] UserRequest user)
        {
            var result = await userRep.Get(user);

            if (result == null) return NotFound(new { ErrorMessage = "Usuário e senha incorretos." });

            result.Token = await tokenSrv.Generate(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("is-valid")]
        [Authorize]
        public async Task<ActionResult<bool>> Post([FromBody] PasswordRequest password)
        {
            var result = await passwordSrv.ValidateAsync(password);

            return Ok(result.IsValid);
        }

        [HttpGet]
        [Route("generate")]
        [Authorize]
        public async Task<ActionResult<bool>> Get()
        {
            var result = await passwordGenerateSrv.Generate();

            return Ok(result);
        }
    }
}
