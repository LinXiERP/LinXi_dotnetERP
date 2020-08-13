using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.BasicInformationManagement.Dtos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 基础信息管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BasicInformationManagementController : ControllerBase
    {
        #region 字段

        private ILogger<ProductionManagementController> _logger; 
        private IServiceProvider _service;
        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        private IPuSupplierService _IPuSupplierService;
        private IPuCommodityServicce _IPuCommodityServicce;
        private IPuCommodityCategoryService _IPuCommodityCategoryService;
        private IPrProductService _IPrProductService;
        private IPrProductCategoryService _IPrProductCategoryService;

        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public BasicInformationManagementController(
            ILogger<ProductionManagementController> logger,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor,
            IPuSupplierService IPuSupplierService,
            IPuCommodityServicce IPuCommodityServicce,
            IPuCommodityCategoryService IPuCommodityCategoryService,
            IPrProductService IPrProductService,
            IPrProductCategoryService IPrProductCategoryService


            )
        {
            _logger = logger;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;

            _IPuSupplierService = IPuSupplierService;
            _IPuCommodityServicce = IPuCommodityServicce;
            _IPuCommodityCategoryService = IPuCommodityCategoryService;
            _IPrProductService = IPrProductService;
            _IPrProductCategoryService = IPrProductCategoryService;
        }

        #endregion 构造函数注入

        #region 供应商资料模块

        /// <summary>
        /// 根据供应商名称联系人姓名筛选供应商
        /// </summary>
        /// <param name="name">供应商名称</param>
        /// <param name="linkman">联系人姓名</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuSupplier>>> GetPS(string name,string linkman)
        {
            var data = (await _IPuSupplierService.Search(t => true)).ToList();
            if (name!=""&&name!=null)
            {
                data = data.Where(d => d.Name.Contains(name)).ToList();
            }
            if (linkman!=""&&linkman!=null)
            {
                data = data.Where(d => d.Linkman.Contains(linkman)).ToList();
            }
            return data;
        }
        /// <summary>
        /// 查找所有供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuSupplier>>> GetPSs()
        {
            var data = (await _IPuSupplierService.Search(t => true)).ToList();
            return data;
        }
        /// <summary>
        /// 根据供应商编号查找供应商
        /// </summary>
        /// <param name="id">供应商编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PuSupplier>> GetPuS(int id)
        {
            var data = await _IPuSupplierService.FindAsyncById(id);
            return data;
        }
        /// <summary>
        /// 修改一条供应商信息
        /// </summary>
        /// <param name="table">一条供应商信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditPS(PuSupplier table)
        {
            var supplier = await _IPuSupplierService.FindAsyncById(table.Id);
            supplier.Address = table.Address;
            supplier.Credit = table.Credit;
            supplier.Email = table.Email;
            supplier.Linkman = table.Linkman;
            supplier.Name = table.Name;
            supplier.Postcode = table.Postcode;
            supplier.Qq = table.Qq;
            supplier.Remark = table.Remark;
            supplier.Tel = table.Tel;
            supplier.Weixin = table.Weixin;
            return await _IPuSupplierService.Edit(supplier);
        }
        /// <summary>
        /// 添加一条供应商信息
        /// </summary>
        /// <param name="table">一条供应商信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddPS(PuSupplier table)
        {
            var supplier = await _IPuSupplierService.FindAsyncById(table.Id);
            if (supplier==null)
            {
                table.OperatorId = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
                table.OperateTime = DateTime.Now;
                return await _IPuSupplierService.Add(table);
            }
            else
            {
                return -99;
            }
        }
        #endregion 供应商资料模块

        #region 原材料资料模块

        /// <summary>
        /// 通过原材料名原材料类型编号筛选原材料
        /// </summary>
        /// <param name="name">原材料名</param>
        /// <param name="id">原材料类型编号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodityDtos>>> GetPC(string name,int? id)
        {
            var data = _IMapper.Map<IEnumerable<PuCommodityDtos>>((await _IPuCommodityServicce.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.SupplierName = (await _IPuSupplierService.FindAsyncById((int)item.SupplierId)).Name;
                item.CategoryName = (await _IPuCommodityCategoryService.FindAsyncById((int)item.CategoryId)).Name;
            }
            if (name != "" && name != null)
            {
                data = data.Where(d => d.Name.Contains(name)).ToList();
            }
            if (id!=null)
            {
                data = data.Where(d => d.CategoryId==(int)id).ToList();
            }
            return data.ToList();
        }
        /// <summary>
        /// 查找所有原材料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodityDtos>>> GetPCs()
        {
            var data = _IMapper.Map<IEnumerable<PuCommodityDtos>>((await _IPuCommodityServicce.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.SupplierName = (await _IPuSupplierService.FindAsyncById((int)item.SupplierId)).Name;
                item.CategoryName = (await _IPuCommodityCategoryService.FindAsyncById((int)item.CategoryId)).Name;
            }
            return data.ToList();
        }
        /// <summary>
        /// 修改一条原材料信息
        /// </summary>
        /// <param name="table">一条原材料信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditPC(PuCommodity table)
        {
            var commodity = await _IPuCommodityServicce.FindAsyncById(table.Id);
            commodity.CategoryId = table.CategoryId;
            commodity.Id = table.Id;
            commodity.LicenseNo = table.LicenseNo;
            commodity.Name = table.Name;
            commodity.Place = table.Place;
            commodity.Price = table.Price;
            commodity.Remark = table.Remark;
            commodity.Spec = table.Spec;
            commodity.SupplierId = table.SupplierId;
            return await _IPuCommodityServicce.Edit(commodity);
        }
        /// <summary>
        /// 添加一条原材料信息
        /// </summary>
        /// <param name="table">一条原材料信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddPC(PuCommodity table)
        {
            var commodity = await _IPuCommodityServicce.FindAsyncById(table.Id);
            if (commodity==null)
            {
                table.OperatorId = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
                table.OperateTime = DateTime.Now;
                table.Stock = 0;
                return await _IPuCommodityServicce.Add(table);
            }
            else
            {
                return -99;
            }
        }
        /// <summary>
        /// 查找所有原材料类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodityCategory>>> GetPCCs()
        {
            var data = (await _IPuCommodityCategoryService.Search(t => true)).ToList();
            return data;
        }
        #endregion 原材料资料模块

        #region 产品资料模块

        /// <summary>
        /// 通过产品名称筛选产品
        /// </summary>
        /// <param name="name">产品名称</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BIMPrProductDtos>>> GetPP(string name)
        {
            var data = _IMapper.Map<IEnumerable<BIMPrProductDtos>>((await _IPrProductService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.CategoryName = (await _IPrProductCategoryService.FindAsyncById((int)item.CategoryId)).Name;
            }
            if (name != "" && name != null)
            {
                data = data.Where(d => d.Name.Contains(name)).ToList();
            }
            return data.ToList();
        }

        /// <summary>
        /// 查找全部产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BIMPrProductDtos>>> GetPPs()
        {
            var data = _IMapper.Map<IEnumerable<BIMPrProductDtos>>((await _IPrProductService.Search(t => true)).ToList());
            foreach (var item in data)
            {
                item.CategoryName = (await _IPrProductCategoryService.FindAsyncById((int)item.CategoryId)).Name;
            }
            return data.ToList();
        }
        /// <summary>
        /// 修改一条产品信息
        /// </summary>
        /// <param name="table">一条产品信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditPP(PrProduct table)
        {
            var product = await _IPrProductService.FindAsyncById(table.Id);
            product.BarCode = table.BarCode;
            product.CategoryId = table.CategoryId;
            product.LicenseNo = table.LicenseNo;
            product.Manufacturer = table.Manufacturer;
            product.Name = table.Name;
            product.Place = table.Place;
            product.Price = table.Price;
            product.Remark = table.Remark;
            product.Spec = table.Spec;
            product.Unit = table.Unit;
            return await _IPrProductService.Edit(product);
        }
        /// <summary>
        /// 添加一条产品信息
        /// </summary>
        /// <param name="table">一条产品信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddPP(PrProduct table)
        {
            var product = await _IPrProductService.FindAsyncById(table.Id);
            if (product==null)
            {
                table.OperatorId = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
                table.OperatorTime = DateTime.Now;
                table.Stock = 0;
                return await _IPrProductService.Add(table);
            }
            else
            {
                return -99;
            }
        }
        /// <summary>
        /// 查找所有产品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductCategory>>> GetPPCs()
        {
            var data = (await _IPrProductCategoryService.Search(t => true)).ToList();
            return data;
        }
        #endregion 产品资料模块
    }
}
