using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private ILogger<LoginController> _logger;
        private IServiceProvider _service;
        private IMapper _IMapper;

        public LoginController(ILogger<LoginController> logger,
            IServiceProvider service,
            IMapper IMapper)
        {
            _logger = logger;
            _service = service;
            _IMapper = IMapper;
        }

        //public ActionResult<InfoResult<string>>
    }
}