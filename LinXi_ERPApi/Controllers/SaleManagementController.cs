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

//using LinXi_Model.DTO.CustomerManageManage.Dtos;
using LinXi_Model.DTO.SaleManagement.Dtos;
using Microsoft.AspNetCore.Server.IISIntegration;
using IdentityModel.AspNetCore.OAuth2Introspection;
using System.Globalization;

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
        private IPrProductService _IPrProductService;
        private IAcDepartmentService _IAcDepartmentService;
        private IAcStaffService _IAcStaffService;
        private ISlOrderService _ISlOrderService;
        private IPrProductCategoryService _IPrProductCategoryService;

        private ISlCustomerService _ISlCustomerService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        private readonly IPuOrderService _IpuOrderService;
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

        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public SaleManagementController(
            ILogger<SaleManagementController> logger,

            ISlSaleOrderService ISlSaleOrderService,
            IPrProductService IPrProductService,
            IAcDepartmentService IAcDepartmentService,
            IAcStaffService IAcStaffService,
            ISlOrderService ISlOrderService,
            ISlCustomerService ISlCustomerService,
            IPrProductCategoryService IPrProductCategoryService,
            IServiceProvider service,

            IPuCommodityCategoryService puCommodityCategoryService,
            IPuOrderService IpuOrderService,
            IPuCommodityServicce IpuCommodityServicce,

            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;

            _ISlSaleOrderService = ISlSaleOrderService;
            _IPrProductService = IPrProductService;
            _IAcDepartmentService = IAcDepartmentService;
            _IAcStaffService = IAcStaffService;
            _ISlOrderService = ISlOrderService;
            _ISlCustomerService = ISlCustomerService;
            _IPrProductCategoryService = IPrProductCategoryService;
            _service = service;

            _IpuOrderService = IpuOrderService;
            _puCommodityCategoryService = puCommodityCategoryService;
            _IpuCommodityServicce = IpuCommodityServicce;

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
        public ActionResult<InfoResult<List<SlOrderOneDtos>>> GetSSO(int pageSize = 10, int pageIndex = 1)
        {
            return new InfoResult<List<SlOrderOneDtos>>(_IMapper.Map<List<SlOrderOneDtos>> //Mapper转换
                (_ISlSaleOrderService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => true, u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        /// <summary>
        /// 获取单条销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderOneDtos>>> GetSSOID(int id)
        {
            var aa = (await _ISlSaleOrderService.Search(u => u.No == id.ToString())).ToList(); ;
            return _IMapper.Map<List<SlOrderOneDtos>>(aa);
        }

        /// <summary>
        /// 修改销售表的资料
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditSSO(SlSaleOrder table)
        {
            return await _ISlSaleOrderService.Edit(table);
        }

        /// <summary>
        /// 添加单条销售信息
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Add(SlSaleOrder table)
        {
            table.OrderStatus = 1;//待提货
            table.AuditStatus = 1;
            table.OperatorTime = DateTime.Now;
            return await _ISlSaleOrderService.Add(table);
        }

        /// <summary>
        /// 删除单条销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<int> Delete(string id)
        {
            var aa = (await _ISlSaleOrderService.Search(s => s.No == id)).FirstOrDefault();
            return await _ISlSaleOrderService.Delete(aa);
        }

        /// <summary>
        /// 以销售状态查询销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderOneDtos>>> GetSSOState(int id)
        {
            var aa = (await _ISlSaleOrderService.Search(s => s.OrderStatus == id)).ToList();
            return _IMapper.Map<List<SlOrderOneDtos>>(aa);
        }

        /// <summary>
        /// 以产品名称查询销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderOneDtos>>> GetSSOProName(int id)
        {
            var aa = (await _ISlSaleOrderService.Search(s => s.ProductId == id)).ToList(); ;
            return _IMapper.Map<List<SlOrderOneDtos>>(aa);
            //return await _ISlSaleOrderService.Search(s => s.ProductId == id);
        }

        /// <summary>
        /// 以产品名称查询产品价格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<decimal> GetSSOProPrice(int id)
        {
            PrProduct aa = (await _IPrProductService.Search(s => s.Id == id)).FirstOrDefault();
            return Convert.ToDecimal(aa.Price);
        }

        [HttpGet]
        public ActionResult<InfoResult<List<SlOrderTwoDtos>>> GetSlOrder(int pageSize = 10, int pageIndex = 1)
        {
            return new InfoResult<List<SlOrderTwoDtos>>(_IMapper.Map<List<SlOrderTwoDtos>> //Mapper转换
                (_ISlOrderService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => true, u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        /// <summary>
        /// 获取所有订单信息(订单id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderTwoDtos>>> GetSlOrderID(int id)
        {
            var aa = (await _ISlOrderService.Search(u => u.No == id.ToString())).ToList();
            return _IMapper.Map<List<SlOrderTwoDtos>>(aa);
        }

        /// <summary>
        /// 获取待检产品信息(产品名称)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderTwoDtos>>> GetPPID(int id)
        {
            var aa = (await _ISlOrderService.Search(u => u.ProductId == id)).ToList();
            return _IMapper.Map<List<SlOrderTwoDtos>>(aa);
        }

        /// <summary>
        /// 获取所有客户信息(名称和id)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlCustomer>>> GetALLSC()
        {
            //var aa = (await _ISlCustomerService.Search(u => true)).ToList();
            //return aa;
            var aa = (await _ISlCustomerService.Search(u => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<SlCustomer> ls = new List<SlCustomer>();
            aa.ForEach(u =>
            {
                ls.Add(new SlCustomer() { Id = u.Id, Name = u.Name });
            });
            return ls;
        }

        /// <summary>
        /// 添加单条订单表信息(SlOrder)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddSlOrder(SlOrder table)
        {
            var cusList = (await _ISlOrderService.Search(t => true)).ToList();
            int max = 0;
            foreach (var item in cusList)
            {
                if (int.Parse(item.No) > max)
                {
                    max = int.Parse(item.No);
                }
            }
            SlOrder so = new SlOrder();
            //so.Id = int.Parse(table.No);
            //so.No = table.No;
            so.No = (max + 1).ToString();
            so.Id = max + 1;
            so.CustomerId = table.CustomerId;
            so.ProductId = table.ProductId;
            so.Nums = table.Nums;
            so.Price = table.Price;
            so.DeliveryDate = table.DeliveryDate;
            so.DeliveryWay = table.DeliveryWay;
            so.OrderDate = DateTime.Now;
            so.OrderAmount = table.OrderAmount;
            so.HandleId = Operator_id;
            so.OperatorId = Operator_id;
            so.OperatorTime = DateTime.Now;
            so.Status = 0;
            so.Remark = table.Remark;
            return await _ISlOrderService.Add(so);
        }

        /// <summary>
        /// 添加单条销售信息(SlSaleOrder)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddSlSaleOrder(SlSaleOrder table)
        {
            //var a = _IMapper.Map<List<SMSlSaleOrderDtos>>(table);
            SlSaleOrder sl = new SlSaleOrder();
            sl.Id = int.Parse(table.No);
            sl.No = table.No;

            sl.ProductId = table.ProductId;
            sl.CustomerId = table.CustomerId;

            sl.OrderId = table.OrderId;
            sl.SaleDate = table.SaleDate;
            sl.Nums = table.Nums;
            sl.Amount = table.Amount;
            sl.AmountWay = table.AmountWay;
            sl.AmountReceivable = table.AmountReceivable;
            sl.AmountReceived = table.AmountReceived;
            sl.HandleId = Operator_id;
            sl.OperatorId = Operator_id;
            sl.OperatorTime = DateTime.Now;
            sl.AuditStatus = 0;
            sl.OrderStatus = 0;
            sl.Remark = table.Remark;

            var bb = (await _ISlOrderService.Search(u => u.No == table.No)).FirstOrDefault();
            bb.Status = 1;
            await _ISlOrderService.Edit(bb);

            return await _ISlSaleOrderService.Add(sl);
        }

        /// <summary>
        /// 修改单条slsaleorder信息(审批1/-1)
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> ShenPi(string id, int status)
        {
            SlSaleOrder aa = (await _ISlSaleOrderService.Search(s => s.No == id)).FirstOrDefault();
            if (status == 1)
            {
                aa.AuditStatus = 1;//通过
                aa.OrderStatus = 1;

                var bb = (await _ISlOrderService.Search(u => u.No == id)).FirstOrDefault();
                bb.Status = 1;
                await _ISlOrderService.Edit(bb);
            }
            else
            {
                aa.AuditStatus = -1;//未通过
                aa.OrderStatus = -1;

                var bb = (await _ISlOrderService.Search(u => u.No == id)).FirstOrDefault();
                bb.Status = -1;
                await _ISlOrderService.Edit(bb);
            }
            return await _ISlSaleOrderService.Edit(aa);
        }

        /// <summary>
        /// 修改单条slsaleorder信息(编辑)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditSlSaleOrder(SlSaleOrder table)
        {
            SlSaleOrder xx = (await _ISlSaleOrderService.Search(u => u.No == table.No)).FirstOrDefault();
            xx.SaleDate = table.SaleDate;
            xx.AmountWay = table.AmountWay;
            xx.Amount = table.Amount;
            xx.Nums = table.Nums;
            xx.AmountReceivable = table.AmountReceivable;
            xx.Remark = table.Remark;
            xx.OrderStatus = 2;

            SlOrder bb = (await _ISlOrderService.Search(u => u.No == table.No)).FirstOrDefault();
            bb.Status = 2;//slorder生成status=2
            await _ISlOrderService.Edit(bb);

            return await _ISlSaleOrderService.Edit(xx);
        }

        /// <summary>
        /// 修改单条slsaleorder信息(结款)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditSlSaleOrderMoney(SlSaleOrder table)
        {
            SlSaleOrder xx = (await _ISlSaleOrderService.Search(u => u.No == table.No)).FirstOrDefault();
            xx.AmountReceived = table.AmountReceived;
            if (table.AmountReceivable == table.AmountReceived)//价格一致的话就执行
            {
                xx.OrderStatus = 3;
                SlOrder bb = (await _ISlOrderService.Search(u => u.No == table.No)).FirstOrDefault();
                bb.Status = 3;//slorder生成status=3
                await _ISlOrderService.Edit(bb);
            }
            else
            {
                xx.OrderStatus = 2;
                SlOrder bb = (await _ISlOrderService.Search(u => u.No == table.No)).FirstOrDefault();
                bb.Status = 2;//slorder生成status=2
                await _ISlOrderService.Edit(bb);
            }
            return await _ISlSaleOrderService.Edit(xx);
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
            List<TJSlOrderDtos> ls = _IMapper.Map<List<TJSlOrderDtos>>((await _ISlOrderService.Search(u => EF.Functions.Like(u.DeliveryDate, $"%{year}%") && EF.Functions.Like(u.Product.Category.Name, $"%{CategoryName}%"))).ToList());

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
                if (dc.ContainsKey(item.DeliveryDate.Value.Month + "月"))
                {
                    dc[item.DeliveryDate.Value.Month + "月"] = (int)(dc[item.DeliveryDate.Value.Month + "月"] + item.Nums);
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
        /// 获取所有商品类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<InfoResult<List<KeyValuePair<string, int>>>>> AllCategoryName()
        {
            var all = (await _IPrProductCategoryService.Search(u => true)).ToList();
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
    }
}