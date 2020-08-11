using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using LinXi_Model.DTO.PurchasingManage.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        #region 字段

        private readonly ILogger<PurchasingManagementController> _logger;
        private readonly IServiceProvider _service;
        private readonly IMapper _IMapper;
        private readonly IPuOrderService _IpuOrderService;
        private IHttpContextAccessor _httpContext;
        private IPuCommodityCategoryService _puCommodityCategoryService;
        private IPuCommodityServicce _IpuCommodityServicce;

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

        #endregion 字段

        #region 依赖注入

        public PurchasingManagementController(
        ILogger<PurchasingManagementController> logger,
        IServiceProvider service,
        IMapper IMapper,
        IHttpContextAccessor httpContextAccessor,
        IPuCommodityCategoryService puCommodityCategoryService,
        IPuOrderService IpuOrderService,
        IPuCommodityServicce IpuCommodityServicce)
        {
            _logger = logger;
            _service = service;
            _IMapper = IMapper;
            _IpuOrderService = IpuOrderService;
            _httpContext = httpContextAccessor;
            _puCommodityCategoryService = puCommodityCategoryService;
            _IpuCommodityServicce = IpuCommodityServicce;
        }

        #endregion 依赖注入

        /// <summary>
        /// 采购单信息（pu_order）
        /// </summary>
        /// <param name="no">采购单编号</param>
        /// <param name="SearchName">商品名（模糊查询）</param>
        /// <param name="CategoryName">商品类别名（模糊查询）</param>
        /// <param name="pageSize">每页数量（分页）</param>
        /// <param name="pageIndex">页码（分页）</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<InfoResult<List<PuOrderDtos>>> PurchaseInfo(string no = "", string SearchName = "", string CategoryName = "", int pageSize = 15, int pageIndex = 1)
        {
            return new InfoResult<List<PuOrderDtos>>(_IMapper.Map<List<PuOrderDtos>> //Mapper转换
                (_IpuOrderService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => EF.Functions.Like(u.No, $"%{no}%") && EF.Functions.Like(u.Commodity.Name, $"%{SearchName}%") && EF.Functions.Like(u.Commodity.Category.Name, $"%{CategoryName}%"), u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        /// <summary>
        /// 获取所有商品类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<InfoResult<List<KeyValuePair<string, int>>>>> AllCategoryName()
        {
            var all = (await _puCommodityCategoryService.Search(u => true)).ToList();
            Dictionary<string, int> dc = new Dictionary<string, int>();
            List<KeyValuePair<string, int>> ls = new List<KeyValuePair<string, int>>();
            all.ForEach(u =>
            {
                if (dc.ContainsKey(u.Name))
                {
                    dc[u.Name] = u.Id;
                }
                else
                {
                    dc.Add(u.Name, u.Id);
                }
            });

            foreach (KeyValuePair<string, int> item in dc)
            {
                ls.Add(item);
            }
            return new InfoResult<List<KeyValuePair<string, int>>>(ls);
        }

        /// <summary>
        /// 获取所有商品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<InfoResult<List<KeyValuePair<string, int>>>>> AllCommodityName()
        {
            var all = (await _IpuCommodityServicce.Search(u => true)).ToList();
            Dictionary<string, int> dc = new Dictionary<string, int>();
            List<KeyValuePair<string, int>> ls = new List<KeyValuePair<string, int>>();
            all.ForEach(u =>
            {
                if (dc.ContainsKey(u.Name))
                {
                    dc[u.Name] = u.Id;
                }
                else
                {
                    dc.Add(u.Name, u.Id);
                }
            });

            foreach (KeyValuePair<string, int> item in dc)
            {
                ls.Add(item);
            }
            return new InfoResult<List<KeyValuePair<string, int>>>(ls);
        }

        /// <summary>
        /// 根据商品类别获取采购单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<InfoResult<PuOrderCreateDtos>>> GetPurchasingByCategoryId(int id)
        {
            var z = await _IpuCommodityServicce.FindAsyncById(id);
            return new InfoResult<PuOrderCreateDtos>(_IMapper.Map<PuOrderCreateDtos>(z));
        }

        /// <summary>
        /// 统计信息
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="CategoryName">商品名</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<InfoResult<List<KeyValuePair<string, int>>>>> AllStatisc(string year = "2020", string CategoryName = "")
        {
            //return new InfoResult<List<PuOrderDtos>>(_IMapper.Map<List<PuOrderDtos>> //Mapper转换
            //   ((await _IpuOrderService.Search(u => EF.Functions.Like(u.PurchaseDate, $"%{year}%") && EF.Functions.Like(u.Commodity.Category.Name, $"%{CategoryName}%"))).ToList()));
            List<PuOrderDtos> ls = _IMapper.Map<List<PuOrderDtos>>((await _IpuOrderService.Search(u => EF.Functions.Like(u.PurchaseDate, $"%{year}%") && EF.Functions.Like(u.Commodity.Category.Name, $"%{CategoryName}%"))).ToList());

            //准备好日期容器
            Dictionary<string, int> dc = new Dictionary<string, int>() {
                { "1月",0},
                { "2月",0},
                { "3月",0},
                { "4月",0},
                { "5月",0},
                { "6月",0},
                { "7月",0},
                { "8月",0},
                { "9月",0},
                { "10月",0},
                { "11月",0},
                { "12月",0}
            };

            //遍历，看日期是否一致
            foreach (var item in ls)
            {
                if (dc.ContainsKey(item.PurchaseDate.Value.Month + "月"))
                {
                    dc[item.PurchaseDate.Value.Month + "月"] = (int)(dc[item.PurchaseDate.Value.Month + "月"] + item.Nums);
                }
            }

            List<KeyValuePair<string, int>> lsw = new List<KeyValuePair<string, int>>();
            foreach (var item in dc)
            {
                lsw.Add(item);
            }

            return new InfoResult<List<KeyValuePair<string, int>>>(lsw);
        }

        /// <summary>
        /// 添加采购单
        /// </summary>
        /// <param name="puOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InfoResult<string>>> CreatePuOrder(PuOrderCreateDtos puOrderCreateDtos)
        {
            if (puOrderCreateDtos.AmountReceived != 0 || puOrderCreateDtos.Nums <= 0)
            {
                return new InfoResult<string>("请勿修改表单数据！") { Code = 201 };
            }
            PuOrder order = _IMapper.Map<PuOrder>(puOrderCreateDtos);
            order.Status = 0;
            order.CommodityId = puOrderCreateDtos.Id;
            order.Batch = "1";
            order.HandleId = Operator_id;
            order.OperatorId = Operator_id;
            order.OperateTime = DateTime.Now;
            order.Id = _IpuOrderService.Search(u => true).Result.Max(u => u.Id) + 1;
            order.No = (int.Parse(_IpuOrderService.Search(u => true).Result.OrderByDescending(u => u.Id).FirstOrDefault().No) + 1).ToString();
            return await _IpuOrderService.Add(order) > 0 ? new InfoResult<string>("采购成功！") : new InfoResult<string>("采购失败！");
        }

        /// <summary>
        /// 退货
        /// </summary>
        /// <param name="puOrder">采购单信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> ReturnBack(PuOrderDtos puOrder)
        {
            var newpuOrder = _IpuOrderService.Search(u => u.No == puOrder.No).Result.FirstOrDefault();
            if (newpuOrder == null)
            {
                return new InfoResult<string>("请勿修改表单数据！") { Code = 201 };
            }
            newpuOrder.Remark = $"操作员：{puOrder.OperatorName}==id：{Operator_id}于{DateTime.Now}进行退货\t";
            newpuOrder.Status = 6;
            return await _IpuOrderService.Edit(newpuOrder) > 0 ? new InfoResult<string>("退货成功！") : new InfoResult<string>("退货失败！");
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
            newpuOrder.Remark = $"操作员：{puOrder.OperatorName}==id：{Operator_id}于{DateTime.Now}修改采购单\t";
            newpuOrder.Nums = puOrder.Nums;
            newpuOrder.AmountWay = puOrder.AmountWay;
            return await _IpuOrderService.Edit(newpuOrder) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
        }

        /// <summary>
        /// 采购单结款
        /// </summary>
        /// <param name="puOrder"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> PayMent(PuOrderDtos puOrder)
        {
            var newpuOrder = (await _IpuOrderService.Search(u => u.Id == puOrder.Id && u.No == puOrder.No)).FirstOrDefault();
            if (newpuOrder == null)
            {
                return new InfoResult<string>("请勿修改表单数据！") { Code = 201 };
            }
            if (newpuOrder.AmountReceivable - puOrder.AmountReceived == 0)
            {
                newpuOrder.Status = 4;
                newpuOrder.Remark = $"操作员：{puOrder.OperatorName}==id：{Operator_id}于{DateTime.Now}结款采购单，结款金额：全款\t";
            }
            newpuOrder.OperatorId = Operator_id;
            newpuOrder.OperateTime = DateTime.Now;
            newpuOrder.AmountReceived = puOrder.AmountReceived;

            return await _IpuOrderService.Edit(newpuOrder) > 0 ? new InfoResult<string>("结款成功！") : new InfoResult<string>("结款失败！");
        }
    }
}