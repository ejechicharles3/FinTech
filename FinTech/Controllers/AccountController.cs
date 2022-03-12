using AutoMapper;
using FinTech.Data;
using FinTech.Models;
using FinTech.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FinTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<Customer> userManager, ILogger<AccountController> logger, 
            IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Loggin Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (userDTO.Roles == null || userDTO.ContributionTypeId == 0)
            //{
            //    return BadRequest("Role must be either User or Administrator, and CustomerType ust be either 1 or 2.");
            //}
            try
            {
                var user = _mapper.Map<Customer>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                
                    await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted( new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
                return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
