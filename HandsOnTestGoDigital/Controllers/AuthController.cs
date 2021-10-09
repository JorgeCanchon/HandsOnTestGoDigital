using HandsOnTestGoDigital.Auth;
using HandsOnTestGoDigital.Common;
using HandsOnTestGoDigital.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTestGoDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IJwtAuthenticationService _authService;

        public AuthController(IJwtAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost()]
        public IActionResult Authenticate([FromBody] AuthInfo user)
        {
            var token = _authService.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
