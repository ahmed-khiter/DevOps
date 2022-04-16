using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevOps.Enum;
using DevOps.Models;
using DevOps.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DevOps.Constants;
using DevOps.Interfaces.Auth;

namespace DevOps.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly SignInManager<BaseUser> signInManager;
        private readonly IRegisterService registerService;
        private readonly ILoginService loginService;

        public AccountController
        (
            UserManager<BaseUser> userManager,
            SignInManager<BaseUser> signInManager,
            IRegisterService authService, ILoginService loginService
        )
        {
            this.registerService = authService;
            this.loginService = loginService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await registerService.RegisterAsync(model);

            if (result.IsAuthenticated == false)
                return BadRequest(result.Messages);

            return Ok(result);

        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromForm] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await loginService.GetTokenAsync(model);

            if (result.IsAuthenticated == false)
                return BadRequest(result.Messages);

            return Ok(result);
        }


        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();

            return Ok();
        }

    }
}