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
        public async Task<ActionResult<IEnumerable<PrProductTaskDtos>>> GetPPT(string year, string month, int? id)
        {
            var data = _IMapper.Map<IEnumerable<PrProductTaskDtos>>((await _IPrProductTaskService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.ProductUnit = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Unit;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.OperatorName = (await _IAcStaffService.FindAsyncById((int)item.OperatorId)).Name;
            }
            if (year != "" && year != null)
            {
                data = data.Where(d => ((DateTime)d.ProductDate).ToString("yyyy") == year).ToList();
            }
            if (month != "" && month != null)
            {
                data = data.Where(d => ((DateTime)d.ProductDate).ToString("MM") == month).ToList();
            }
            if (id != null)
            {
                data = data.Where(d => d.Id == id).ToList();
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
            var task = await _IPrProductTaskService.FindAsyncById(table.Id);
            task.No = table.No;
            task.ProductId = table.ProductId;
            task.Nums = table.Nums;
            task.ProductDate = table.ProductDate;
            task.Batch = table.Batch;
            task.DepartmentId = table.DepartmentId;
            task.Remark = table.Remark;
            return await _IPrProductTaskService.Edit(task);
        }

        /// <summary>
        /// 添加一行生产计划
        /// </summary>
        /// <param name="table">一行生产计划的实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddPPT(PrProductTask table)
        {
            int taskid = table.Id;
            var task = await _IPrProductTaskService.FindAsyncById(taskid);
<<<<<<< HEAD
            if (task == null)
=======
            if (task==null)
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
            {
                table.OperatorId = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
                table.OperateTime = DateTime.Now;
                table.Status = 0;
                return await _IPrProductTaskService.Add(table);
            }
            else
            {
                return -99;
            }
        }

        /// <summary>
        /// 删除一行生产计划
        /// </summary>
        /// <param name="taskid">一行生产计划的编号</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> DeletePPT(int taskid)
        {
            var table = await _IPrProductTaskService.FindAsyncById(taskid);
            return await _IPrProductTaskService.Delete(table);
        }

        /// <summary>
        /// 查询订单表未制定生产计划的订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrder>>> GetSOS()
        {
            var z = (await _ISlOrderService.Search(t => t.Status == 1)).Select(u => new { u.Id }).ToList();
            List<SlOrder> ls = new List<SlOrder>();
            foreach (var item in z)
            {
                ls.Add(new SlOrder() { Id = item.Id });
            }
            return ls;
        }

        /// <summary>
        /// 查询产品名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProduct>>> GetPPs()
        {
            var z = (await _IPrProductService.Search(t => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<PrProduct> ls = new List<PrProduct>();
            foreach (var item in z)
            {
                ls.Add(new PrProduct() { Id = item.Id, Name = item.Name });
            }
            return ls;
        }

        #endregion 生产计划模块

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
            var data = _IMapper.Map<IEnumerable<PrProductMaterialDtos>>((await _IPrProductMaterialService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.StaffName = (await _IAcStaffService.FindAsyncById((int)item.StaffId)).Name;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.CommodityName = (await _IPuCommodityServicce.FindAsyncById((int)item.CommodityId)).Name;
                item.CommoditySpec = (await _IPuCommodityServicce.FindAsyncById((int)item.CommodityId)).Spec;
            }
            if (departmentid != null)
            {
                data = data.Where(d => d.DepartmentId == departmentid).ToList();
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
            var data = _IMapper.Map<IEnumerable<PrProductMaterialDtos>>((await _IPrProductMaterialService.Search(t => true)).ToList());
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
            var material = await _IPrProductMaterialService.FindAsyncById(table.Id);
            material.CommodityId = table.CommodityId;
            material.DepartmentId = table.DepartmentId;
            material.Nums = table.Nums;
            material.Remark = table.Remark;
            material.StaffId = table.StaffId;
            material.TaskId = table.TaskId;
            material.Uses = table.Uses;
<<<<<<< HEAD
            var task = await _IPrProductTaskService.FindAsyncById((int)table.TaskId);
            if (task.Status == 0)
            {
                task.Status = 1;
                await _IPrProductTaskService.Edit(task);
            }
=======
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
            return await _IPrProductMaterialService.Edit(material);
        }

        /// <summary>
        /// 添加领料单
        /// </summary>
        /// <param name="table">一条领料单记录</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddPPM(PrProductMaterial table)
        {
            var meterial = await _IPrProductMaterialService.FindAsyncById(table.Id);
<<<<<<< HEAD
            if (meterial == null)
=======
            if (meterial==null)
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
            {
                table.OperatorId = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
                table.OperateTime = DateTime.Now;
                table.Status = 0;
                int i = await _IPrProductMaterialService.Add(table);
<<<<<<< HEAD
                if (i > 0)
=======
                if (i>0)
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
                {
                    var task = await _IPrProductTaskService.FindAsyncById((int)table.TaskId);
                    if (task.Status == 0)
                    {
                        task.Status = 1;
                        await _IPrProductTaskService.Edit(task);
                    }
                }
                return i;
            }
            else
            {
                return -99;
            }
        }

        /// <summary>
        /// 删除一行领料单
        /// </summary>
        /// <param name="id">领料单编号</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> DeletePPM(int id)
        {
            var table = await _IPrProductMaterialService.FindAsyncById(id);
            return await _IPrProductMaterialService.Delete(table);
        }

        /// <summary>
        /// 查询原材料名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodity>>> GetPCs()
        {
            var z = (await _IPuCommodityServicce.Search(t => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<PuCommodity> ls = new List<PuCommodity>();
            foreach (var item in z)
            {
                ls.Add(new PuCommodity() { Id = item.Id, Name = item.Name });
            }
            return ls;
        }

        /// <summary>
        /// 查询部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDepartment>>> GetADs()
        {
            var z = (await _IAcDepartmentService.Search(t => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<AcDepartment> ls = new List<AcDepartment>();
            foreach (var item in z)
            {
                ls.Add(new AcDepartment() { Id = item.Id, Name = item.Name });
            }
            return ls;
        }

        /// <summary>
        /// 查询所有员工
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcStaff>>> GetASs()
        {
<<<<<<< HEAD
            var z = (await _IAcStaffService.Search(t => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<AcStaff> ls = new List<AcStaff>();
            foreach (var item in z)
            {
                ls.Add(new AcStaff() { Id = item.Id, Name = item.Name });
            }
            return ls;
=======
            return (await _IAcStaffService.Search(t => true)).ToList();
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
        }

        #endregion 领料管理模块

        #region 产品生产模块

        /// <summary>
        /// 生产完成
        /// </summary>
        /// <param name="taskid">计划表编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> EditStatuPPT(int taskid)
        {
            var product = await _IPrProductTaskService.FindAsyncById(taskid);
            product.Status = 4;
            return await _IPrProductTaskService.Edit(product);
        }

        /// <summary>
        /// 通过计划编号产品编号生产状态查询生产计划
        /// </summary>
        /// <param name="id">计划编号</param>
        /// <param name="productid">产品ID</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductTaskDtos>>> GetPPPT(int? id, int? productid, int? status)
        {
            var data = _IMapper.Map<IEnumerable<PrProductTaskDtos>>((await _IPrProductTaskService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.ProductName = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Name;
                item.ProductUnit = (await _IPrProductService.FindAsyncById((int)item.ProductId)).Unit;
                item.DepartmentName = (await _IAcDepartmentService.FindAsyncById((int)item.DepartmentId)).Name;
                item.OperatorName = (await _IAcStaffService.FindAsyncById((int)item.OperatorId)).Name;
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
<<<<<<< HEAD

=======
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
            var record = await _IIcProductRecordService.FindAsyncById(table.Id);
            record.Batch = table.Batch;
            record.Nums = table.Nums;
            record.ProductId = table.ProductId;
            record.Remark = table.Remark;
            record.SourceCategory = table.SourceCategory;
            record.DepartmentId = table.DepartmentId;
            return await _IIcProductRecordService.Edit(record);
        }
        /// <summary>
        /// 添加一条生产表的数据
        /// </summary>
        /// <param name="table">一行生产单的实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddIPR(IcProductRecord table)
        {
            var record = await _IIcProductRecordService.FindAsyncById(table.Id);
            if (record==null)
            {
                table.OperatorId = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
                table.OperateTime = DateTime.Now;
                table.Status = 0;
                return await _IIcProductRecordService.Add(table);
            }
            else
            {
                return -99;
            }
        }
        /// <summary>
        /// 删除一条生产表的数据
        /// </summary>
        /// <param name="id">生产编号</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> DeleteIPR(int id)
        {
            var table = await _IIcProductRecordService.FindAsyncById(id);
            return await _IIcProductRecordService.Delete(table);
        }
        
>>>>>>> 8d8007523ffaaab5c4a441dc29b5c8f7c367c557
        #endregion 产品生产模块
    }
}