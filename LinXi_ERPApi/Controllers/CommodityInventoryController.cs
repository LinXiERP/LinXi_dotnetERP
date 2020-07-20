using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityInventoryController : ControllerBase
    {
        private ILogger<CommodityInventoryController> _logger;

        private IAcDepartmentService _IAcDepartmentService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;
    }
}
