using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 采购管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PurchasingManagementController : ControllerBase
    {
        private readonly ILogger<PurchasingManagementController> _logger;
        private readonly IServiceProvider _service;
        private readonly IMapper _IMapper;
        private readonly IPuOrderService _IpuOrderService;
        private IHttpContextAccessor _httpContext;
        private IPuCommodityCategoryService _puCommodityCategoryService;

        /// <summary>
        /// 操作人ID
        /// </summary>
        public int Operator_id
        {
            get
            {
                return int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
            }
        }

        public PurchasingManagementController(
            ILogger<PurchasingManagementController> logger,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor,
            IPuCommodityCategoryService puCommodityCategoryService,
            IPuOrderService IpuOrderService)
        {
            _logger = logger;
            _service = service;
            _IMapper = IMapper;
            _IpuOrderService = IpuOrderService;
            _httpContext = httpContextAccessor;
            _puCommodityCategoryService = puCommodityCategoryService;
        }

        /// <summary>
        /// 采购单信息（pu_order）
        /// </summary>
        /// <returns>采购单集合</returns>
        [HttpGet]
        public ActionResult<InfoResult<List<PuOrderDtos>>> PurchaseInfo(string no = "", string SearchName = "", string CategoryName = "", int pageSize = 1, int pageIndex = 1)
        {
            return new InfoResult<List<PuOrderDtos>>(_IMapper.Map<List<PuOrderDtos>>
                (_IpuOrderService.SearchByPage(pageSize, pageIndex, out int count, u => EF.Functions.Like(u.No, $"%{no}%") && EF.Functions.Like(u.Commodity.Name, $"%{SearchName}%") && EF.Functions.Like(u.Commodity.Category.Name, $"%{CategoryName}%"), u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        /// <summary>
        /// 修改采购数量/采购方式
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> PurchaseInfoEdit(PuOrderDtos puOrder)
        {
            var newpuOrder = await _IpuOrderService.FindAsyncById(puOrder.Id);
            if (newpuOrder == null)
            {
                return new InfoResult<string>("请勿修改表单数据！") { Code = 201 };
            }
            newpuOrder.OperatorId = Operator_id;
            newpuOrder.OperateTime = DateTime.Now;
            newpuOrder.Nums = puOrder.Nums;
            newpuOrder.AmountWay = puOrder.AmountWay;
            return await _IpuOrderService.Edit(newpuOrder) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
        }

        /// <summary>
        /// 获取所有商品类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<InfoResult<List<string>>>> AllCategoryName()
        {
            var all = (await _puCommodityCategoryService.Search(u => true)).ToList();
            HashSet<string> set = new HashSet<string>();
            all.ForEach(u =>
            {
                set.Add(u.Name);
            });
            return new InfoResult<List<string>>(set.ToList());
        }
    }
}