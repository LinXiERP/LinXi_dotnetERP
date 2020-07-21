using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 销售管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SaleManagementController : ControllerBase
    {
        #region 字段

        private ILogger<SaleManagementController> _logger;

        private ISlSaleOrderService _ISlSaleOrderService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public SaleManagementController(
            ILogger<SaleManagementController> logger,
            ISlSaleOrderService ISlSaleOrderService,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _ISlSaleOrderService = ISlSaleOrderService;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入
        /// <summary>
        /// 获取所有销售信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IQueryable<SlSaleOrder>> GetSSO()
        {
            return await _ISlSaleOrderService.Search(u=>true);
        }
        /// <summary>
        /// 获取单条销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<SlSaleOrder> GetSSOID(int id)
        {
            return await _ISlSaleOrderService.FindAsyncById(id);
        }
        /// <summary>
        /// 修改销售表的资料
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditSSO(SlSaleOrder table)
        {
            return await _ISlSaleOrderService.Edit(table); ;
        }
        /// <summary>
        /// 添加单条销售信息
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Add(SlSaleOrder table)
        {
            return await _ISlSaleOrderService.Add(table);
        }
        /// <summary>
        /// 删除单条销售信息
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> Delete(SlSaleOrder table)
        {
            return await _ISlSaleOrderService.Delete(table);
        }
        /// <summary>
        /// 以销售状态查询销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IQueryable<SlSaleOrder>> GetSSOState(int id)
        {
            return await _ISlSaleOrderService.Search(s=>s.OrderStatus == id);
        }
        /// <summary>
        /// 以产品类型查询销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IQueryable<SlSaleOrder>> GetSSOProType(int id)
        {
            return await _ISlSaleOrderService.Search(s => s.OrderStatus == id);
        }
    }
}
