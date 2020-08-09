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
        private IPuCommodityServicce _IPuCommodityServicce;
        private IIcProductRecordService _IIcProductRecordService;
        private IPrProductMaterialService _IPrProductMaterialService;
        private IAcStaffService _IAcStaffService;
        private ISlOrderService _ISlOrderService;
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
            IPuCommodityServicce IPuCommodityServicce,
            IIcProductRecordService IIcProductRecordService,
            IPrProductMaterialService IPrProductMaterialService,
            IAcStaffService IAcStaffService,
            IServiceProvider service,
            ISlOrderService ISlOrderService,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _IPrProductTaskService = IPrProductTaskService;
            _IPrProductService = IPrProductService;
            _IIcProductRecordService = IIcProductRecordService;
            _IAcDepartmentService = IAcDepartmentService;
            _ISlOrderService = ISlOrderService;
            _IPuCommodityServicce = IPuCommodityServicce;
            _IPrProductMaterialService = IPrProductMaterialService;
            _IAcStaffService = IAcStaffService;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入
        
        #region 生产计划模块
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
            var data = _IMapper.Map<IEnumerable<PrProductTaskDtos>>((await _IPrProductTaskService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.ProductUnit = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Unit;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.OperatorName = (await _IAcStaffService.FindAsyncById((int)item.OperatorId)).Name;
            }
            if (year!=""&& year !=null)
            {
                data = data.Where(d => ((DateTime)d.ProductDate).ToString("yyyy") == year).ToList();
            }
            if (month != ""&&month!=null)
            {
                data = data.Where(d => ((DateTime)d.ProductDate).ToString("MM") == month).ToList();
            }
            if (id!=null)
            {
                data = data.Where(d =>d.Id==id).ToList();
            }
            return data.ToList();
        }
        /// <summary>
        /// 获取全部生产计划信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductTaskDtos>>> GetPPTs()
        {
            var data = _IMapper.Map<IEnumerable<PrProductTaskDtos>>((await _IPrProductTaskService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.ProductUnit = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Unit;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.OperatorName = (await _IAcStaffService.FindAsyncById((int)item.OperatorId)).Name;
            }
            return data.ToList();
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
        public async Task<int> AddPPT(PrProductTask table)
        {
            return await _IPrProductTaskService.Add(table);
        }
        /// <summary>
        /// 删除一行生产计划
        /// </summary>
        /// <param name="table">一行生产计划的实体</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> DeletePPT(PrProductTask table)
        {
            return await _IPrProductTaskService.Delete(table);
        }
        /// <summary>
        /// 查询订单表未制定生产计划的订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrder>>> GetSOS()
        {
             return (await _ISlOrderService.Search(t => t.Status==1)).ToList();
        }
        /// <summary>
        /// 查询产品名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProduct>>> GetPPs()
        {
            return (await _IPrProductService.Search(t=>true)).ToList();
        }
        #endregion 生产计划

        #region 领料管理模块
        /// <summary>
        /// 通过部门编号计划编号筛选领料单
        /// </summary>
        /// <param name="departmentid">部门编号</param>
        /// <param name="id">领料单编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductMaterialDtos>>> GetPPM(int? departmentid, int? id)
        {
            var data = _IMapper.Map<IEnumerable<PrProductMaterialDtos>>((await _IPrProductTaskService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.StaffName = (await _IAcStaffService.FindAsyncById((int)item.StaffId)).Name;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.CommodityName = (await _IPuCommodityServicce.FindAsyncById((int)item.CommodityId)).Name;
                item.CommoditySpec= (await _IPuCommodityServicce.FindAsyncById((int)item.CommodityId)).Spec;
            }
            if (departmentid != null)
            {
                data = data.Where(d => d.DepartmentId==departmentid).ToList();
            }
            if (id != null)
            {
                data = data.Where(d => d.Id == id).ToList();
            }
            return data.ToList();
        }
        /// <summary>
        /// 查询所有领料单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductMaterialDtos>>> GetPPMs()
        {
            var data = _IMapper.Map<IEnumerable<PrProductMaterialDtos>>((await _IPrProductTaskService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.StaffName = (await _IAcStaffService.FindAsyncById((int)item.StaffId)).Name;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.CommodityName = (await _IPuCommodityServicce.FindAsyncById((int)item.CommodityId)).Name;
                item.CommoditySpec = (await _IPuCommodityServicce.FindAsyncById((int)item.CommodityId)).Spec;
            }
            return data.ToList();
        }
        /// <summary>
        /// 修改领料单
        /// </summary>
        /// <param name="table">一条领料单记录</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditPPM(PrProductMaterial table)
        {
            return await _IPrProductMaterialService.Edit(table);
        }
        /// <summary>
        /// 添加领料单
        /// </summary>
        /// <param name="table">一条领料单记录</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddPPM(PrProductMaterial table)
        {
            return await _IPrProductMaterialService.Add(table);
        }
        /// <summary>
        /// 删除一行领料单
        /// </summary>
        /// <param name="table">一行领料单的实体</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> DeletePPM(PrProductMaterial table)
        {
            return await _IPrProductMaterialService.Delete(table);
        }
        /// <summary>
        /// 查询原材料名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodity>>> GetPCs()
        {
            return (await _IPuCommodityServicce.Search(t => true)).ToList();
        }
        /// <summary>
        /// 查询部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDepartment>>> GetADs()
        {
            return (await _IAcDepartmentService.Search(t => true)).ToList();
        }
        /// <summary>
        /// 根据部门编号查询员工
        /// </summary>
        /// <param name="id">部门ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcStaff>>> GetASs(int id)
        {
            return (await _IAcStaffService.Search(t => t.DepartmentId==id)).ToList();
        }
        #endregion 领料管理模块

        #region 产品生产模块

        /// <summary>
        /// 通过产品编号生产状态状态生产单编号筛选生产单
        /// </summary>
        /// <param name="productid">产品编号</param>
        /// <param name="status">生产状态</param>
        /// <param name="id">生产单编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcProductRecordDtos>>> GetIPR(int? productid,int? status, int? id)
        {
            var data = _IMapper.Map<IEnumerable<IcProductRecordDtos>>((await _IIcProductRecordService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.ProductUnit = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Unit;
            }
            if (productid != null)
            {
                data = data.Where(d => d.ProductId == productid).ToList();
            }
            if (status != null)
            {
                data = data.Where(d => d.Status == status).ToList();
            }
            if (id != null)
            {
                data = data.Where(d => d.Id == id).ToList();
            }
            return data.ToList();
        }
        /// <summary>
        /// 查询所有生产单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcProductRecordDtos>>> GetIPRs()
        {
            var data = _IMapper.Map<IEnumerable<IcProductRecordDtos>>((await _IIcProductRecordService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.ProductUnit = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Unit;
            }
            return data.ToList();
        }
        /// <summary>
        /// 修改一条生产表的数据
        /// </summary>
        /// <param name="table">一行生产单的实体</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditIPRs(IcProductRecord table)
        {
            return await _IIcProductRecordService.Edit(table);
        }
        /// <summary>
        /// 添加一条生产表的数据
        /// </summary>
        /// <param name="table">一行生产单的实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddIPR(IcProductRecord table)
        {
            return await _IIcProductRecordService.Add(table);
        }
        /// <summary>
        /// 删除一条生产表的数据
        /// </summary>
        /// <param name="table">一行生产单的实体</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> DeleteIPR(IcProductRecord table)
        {
            return await _IIcProductRecordService.Delete(table);
        }
        
        #endregion 产品生产模块
    }
}
