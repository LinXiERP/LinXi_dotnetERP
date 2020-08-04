using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.ProductionManagement.Dtos;

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
        private IPrProductService _IPrProductService;
        private IAcDepartmentService _IAcDepartmentService;
        private IAcStaffService _IAcStaffService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;


        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public ProductionManagementController(
            ILogger<ProductionManagementController> logger,
            IPrProductTaskService IPrProductTaskService,
            IPrProductService IPrProductService,
            IAcDepartmentService IAcDepartmentService,
            IAcStaffService IAcStaffService,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _IPrProductTaskService = IPrProductTaskService;
            _IPrProductService = IPrProductService;
            _IAcDepartmentService = IAcDepartmentService;
            _IAcStaffService = IAcStaffService;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入
        
        #region 生产计划
        /// <summary>
        /// 通过年份月份计划编号筛选计划
        /// </summary>
        /// <param name="year">生产年份</param>
        /// <param name="month">生产月份</param>
        /// <param name="id">计划编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductTaskDtos>>> GetPPT(string year,string month,int? id)
        {
            var data = _IMapper.Map<IEnumerable<PrProductTaskDtos>>(await _IPrProductTaskService.Search(t => true)).ToList();
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.OperatorName = (await _IAcStaffService.FindAsyncById((int)item.OperatorId)).Name;
            }
            if (year!="")
            {
                data = data.Where(d => ((DateTime)d.ProductDate).ToString("yyyy") == year).ToList();
            }
            if (month != "")
            {
                data = data.Where(d => ((DateTime)d.ProductDate).ToString("MM") == month).ToList();
            }
            if (id!=null)
            {
                data = data.Where(d =>d.Id==id).ToList();
            }
            return data;
        }
        /// <summary>
        /// 获取全部生产计划信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductTaskDtos>>> GetPPTs()
        {
            var data = _IMapper.Map<IEnumerable<PrProductTaskDtos>>(await _IPrProductTaskService.Search(t => true)).ToList();
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.OperatorName = (await _IAcStaffService.FindAsyncById((int)item.OperatorId)).Name;
            }
            return data;
        }
        /// <summary>
        /// 修改生产计划
        /// </summary>
        /// <param name="table">一行生产计划的实体</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditPPT(PrProductTask table)
        {
            return await _IPrProductTaskService.Edit(table);
        }
        /// <summary>
        /// 添加一行生产计划
        /// </summary>
        /// <param name="table">一行生产计划的实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Add(PrProductTask table)
        {
            return await _IPrProductTaskService.Add(table);
        }
        /// <summary>
        /// 删除一行生产计划
        /// </summary>
        /// <param name="table">一行生产计划的实体</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> Delete(PrProductTask table)
        {
            return await _IPrProductTaskService.Delete(table);
        }
        #endregion 生产计划
    }
}
