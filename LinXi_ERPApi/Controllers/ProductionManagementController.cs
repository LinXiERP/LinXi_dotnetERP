using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;

//using LinXi_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 生产管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductionManagementController : ControllerBase
    {
        #region 字段

        private ILogger<ProductionManagementController> _logger;

        private IPrProductTaskService _IPrProductTaskService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;


        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public ProductionManagementController(
            ILogger<ProductionManagementController> logger,
            IPrProductTaskService IPrProductTaskService,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _IPrProductTaskService = IPrProductTaskService;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入
        /// <summary>
        /// 获取单个生产计划的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PrProductTask> GetPPT(int id)
        {
            return await _IPrProductTaskService.FindAsyncById(id); ;
        }
        /// <summary>
        /// 获取全部生产计划信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PrProductTask>> GetPPTs()
        {
            return (await _IPrProductTaskService.Search(t=>true)).ToList(); ;
        }
    }
}
