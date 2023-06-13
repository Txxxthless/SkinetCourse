using System.Security.Claims;
using API.DTOs;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> singInManager,
            ITokenService tokenService,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                return Unauthorized(new ApiResponse(401));
            }

            var result = await _singInManager.CheckPasswordSignInAsync(
                user,
                loginDTO.Password,
                false
            );

            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));
            }

            return Ok(
                new UserDTO()
                {
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    DisplayName = user.DisplayName
                }
            );
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var user = new AppUser()
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(
                new UserDTO()
                {
                    DisplayName = user.DisplayName,
                    Token = _tokenService.CreateToken(user),
                    Email = user.Email
                }
            );
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailFromClaimsPrincipal(User);

            return Ok(
                new UserDTO()
                {
                    DisplayName = user.DisplayName,
                    Token = _tokenService.CreateToken(user),
                    Email = user.Email
                }
            );
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpGet("address")]
        [Authorize]
        public async Task<ActionResult<AddressDTO>> GetUserAdress()
        {
            var user = await _userManager.FindUserByClaimsPrincipalWithAdress(User);

            return Ok(_mapper.Map<Address, AddressDTO>(user.Address));
        }

        [HttpPut("address")]
        [Authorize]
        public async Task<ActionResult<AddressDTO>> UpdateUserAddress(AddressDTO address)
        {
            var user = await _userManager.FindUserByClaimsPrincipalWithAdress(HttpContext.User);

            user.Address = _mapper.Map<AddressDTO, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(_mapper.Map<Address, AddressDTO>(user.Address));
            }

            return BadRequest("Updating failed");
        }
    }
}
