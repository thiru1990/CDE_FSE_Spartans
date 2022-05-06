using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SellerAPI.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SellerAPI.Controllers
{    
    [ApiController]
    [ApiVersion("1.0")]    
    public class AuthenticationController : Controller
    {
        #region Declarations
        private readonly ILogger<AuthenticationController> _logger;
        private readonly Service.Contract.IAuthenticationService _AuthenticationService;

        #endregion

        #region Constructor
        public AuthenticationController(ILogger<AuthenticationController> logger, Service.Contract.IAuthenticationService AuthenticationService)
        {
            _logger = logger;
            _AuthenticationService = AuthenticationService;
        }
        #endregion

        #region Operations
        //[AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(string email)
        {
            _logger.LogInformation("AuthenticationController AddProduct IN");
          var response =  await _AuthenticationService.GenerateSecurityToken(email);
            _logger.LogInformation("AuthenticationController AddProduct OUT");
            return Ok(response);
        }   
        #endregion
    }
}
