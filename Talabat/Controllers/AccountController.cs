using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Models.Identity;
using Talabat.Dtos;
using Talabat.Error;

namespace Talabat.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> _userManager,SignInManager<AppUser> signInManager)
        {
            userManager = _userManager;
            SignInManager = signInManager;
        }

        public SignInManager<AppUser> SignInManager { get; }

        [HttpPost("login")]
        public async Task<ActionResult<userDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if(user == null)
            {
                return Unauthorized(new ApiResponse(401));

            }
            var result = await SignInManager.CheckPasswordSignInAsync(user,loginDto.Password,true);
            if (!result.Succeeded )
            {

                return Unauthorized(new ApiResponse(401));
            }

            return Ok(new userDto { DisplayName = user.DisplayName, Email = user.Email, Token = "ksdfsdfs" });

        }


        [HttpPost("Register")]
        public async Task<ActionResult <userDto>> Register(RegisterDto registerDto)
        {
            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email.Split("@")[0]
            };


               var result =await userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(new userDto()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                 Token ="LLKJJHH"
            });



        }
    }
}
