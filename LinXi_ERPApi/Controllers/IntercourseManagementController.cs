using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using LinXi_Model.DTO.IntercourseManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    ///  往来管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class IntercourseManagementController : ControllerBase
    {
        private ILogger<ProductionManagementController> _logger;
        private IServiceProvider _service;
        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        //销售订单表
        private ISlOrderService _ISlOrderService;

        //销售表
        private ISlSaleOrderService _ISlSaleOrderService;

        private IPuOrderService _puOrderService;

        public IntercourseManagementController(
              ILogger<ProductionManagementController> logger,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor,
            ISlOrderService slOrderService,
            ISlSaleOrderService slSaleOrder,
            IPuOrderService puOrderService
            )
        {
            _logger = logger;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
            _ISlOrderService = slOrderService;
            _ISlSaleOrderService = slSaleOrder;
            _puOrderService = puOrderService;
        }

        /// <summary>
        /// 获取销售结款单
        /// </summary>
        /// <param name="Slno"></param>
        /// <param name="OrderId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public InfoResult<List<SaleNoPayDtos>> GetAllSlSaryOrder(string Slno = "", int OrderId = 0, int pageSize = 15, int pageIndex = 1)
        {
            int count = 0;
            //查出所有状态为已出货（1）的销售单Sl_Sale_Order
            var t = OrderId == 0 && String.IsNullOrEmpty(Slno) ? _ISlSaleOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.OrderStatus == 1, u => u.Id, false) :
                   _ISlSaleOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.OrderId == OrderId && u.No == Slno && u.OrderStatus == 1, u => u.Id, false);
            return new InfoResult<List<SaleNoPayDtos>>(_IMapper.Map<List<SaleNoPayDtos>>(t.ToList())) { Msg = count.ToString() };
        }

        /// <summary>
        /// 获取采购结款单
        /// </summary>
        /// <param name="no"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public InfoResult<List<PuOrderDtos>> GetAllPuOrder(string no = "", int pageSize = 15, int pageIndex = 1)
        {
            int count = 0;
            //查出所有状态为已结款（3）的采购单pu_Order
            var t = String.IsNullOrEmpty(no) ? _puOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.Status == 3, u => u.Id, false) :
                _puOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.Status == 3 && EF.Functions.Like(u.No, $"{no}"), u => u.Id, false);

            return new InfoResult<List<PuOrderDtos>>(_IMapper.Map<List<PuOrderDtos>>(t.ToList())) { Msg = count.ToString() };
        }

        /// <summary>
        /// 获取采购退货单
        /// </summary>
        /// <param name="no"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public InfoResult<List<PuOrderDtos>> GetAllPuOrderReturn(string no = "", int pageSize = 15, int pageIndex = 1)
        {
            int count = 0;
            //查出所有状态为已结款（6）的采购单pu_Order
            var t = String.IsNullOrEmpty(no) ? _puOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.Status == 6, u => u.Id, false) :
                _puOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.Status == 6 && EF.Functions.Like(u.No, $"{no}"), u => u.Id, false);

            return new InfoResult<List<PuOrderDtos>>(_IMapper.Map<List<PuOrderDtos>>(t.ToList())) { Msg = count.ToString() };
        }

        /// <summary>
        /// 获取销售发货单
        /// </summary>
        /// <param name="Slno"></param>
        /// <param name="OrderId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public InfoResult<List<SaleNoPayDtos>> GetAllPurchasingSend(string Slno = "", int OrderId = 0, int pageSize = 15, int pageIndex = 1)
        {
            int count = 0;
            //查出所有状态为已出货（1）的销售单Sl_Sale_Order
            var t = OrderId == 0 && String.IsNullOrEmpty(Slno) ? _ISlSaleOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.OrderStatus == 3, u => u.Id, false) :
                   _ISlSaleOrderService.SearchByPage(pageSize, pageIndex, out count, u => u.OrderId == OrderId && u.No == Slno && u.OrderStatus == 3, u => u.Id, false);
            return new InfoResult<List<SaleNoPayDtos>>(_IMapper.Map<List<SaleNoPayDtos>>(t.ToList())) { Msg = count.ToString() };
        }
    }
}