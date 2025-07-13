using Identity.Application.DTOs;
using Identity.Application.UseCases.Authentication.Commands.Login;
using Identity.Application.UseCases.Authentication.Commands.Logout;
using Identity.Application.UseCases.Authentication.Commands.Refresh;
using Identity.Application.UseCases.Authentication.Commands.RegisterAdministrator;
using Identity.Application.UseCases.Authentication.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] NewUserDTO newUser)
        {
            var registerUserCommand = new RegisterUserCommand
            {
                userDTO = newUser
            };

            try
            {
                await _mediator.Send(registerUserCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAdministrator([FromBody] NewUserDTO newUser)
        {
            var registerAdminCommand = new RegisterAdministratorCommand
            {
                userDTO = newUser
            };

            try
            {
                await _mediator.Send(registerAdminCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserCredentialsDTO userCredentials)
        {
            var loginCommand = new LoginCommand
            {
                userCredentialsDTO = userCredentials
            };

            AuthenticationModel authenticationModel = await _mediator.Send(loginCommand);

            if(authenticationModel is null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(authenticationModel);
        }

        [Authorize]
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Logout([FromBody] RefreshTokenModel refreshTokenModel)
        {
            if (refreshTokenModel.UserName == null)
                return Forbid();

            var logoutCommand = new LogoutCommand
            {
                 refreshTokenModel = refreshTokenModel
            };

            await _mediator.Send(logoutCommand);

            return Accepted(new { message = "Logout successful" });
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenModel refreshTokenModel)
        {
            var refreshCommand = new RefreshCommand
            {
                refreshTokenCredentials = refreshTokenModel
            };

            AuthenticationModel authenticationModel = await _mediator.Send(refreshCommand);
            if (authenticationModel is null)
            {
                return Forbid();
            }

            if(!authenticationModel.isAuthorized)
            {
                return Unauthorized(new { message = "Invalid refresh token" });
            }

            return Ok(authenticationModel);

        }


    }
}
