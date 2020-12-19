using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.QualityManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 质量管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class QualityManagementController : ControllerBase
    {
        #region 字段

        private ILogger<QualityManagementController> _logger;

        private ISlSaleOrderService _ISlSaleOrderService;
        private IPrProductService _IPrProductService;
        private IAcDepartmentService _IAcDepartmentService;
        private IAcStaffService _IAcStaffService;
        private IPuOrderService _IPuOrderService;
        private IQmCommodityService _IQmCommodityService;
        private IPrProductTaskService _IPrProductTaskService;
        private IQmProductService _IQmProductService;
        private IPuCommodityServicce _IPuCommodityService;

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

        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public QualityManagementController(
            ILogger<QualityManagementController> logger,

            ISlSaleOrderService ISlSaleOrderService,
            IPrProductService IPrProductService,
            IAcDepartmentService IAcDepartmentService,
            IAcStaffService IAcStaffService,
            IPuOrderService IPuOrderService,
            IQmCommodityService IQmCommodityService,
            IPrProductTaskService IPrProductTaskService,
            IQmProductService IQmProductService,
            IPuCommodityServicce IPuCommodityService,
            IServiceProvider service,

            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;

            _ISlSaleOrderService = ISlSaleOrderService;
            _IPrProductService = IPrProductService;
            _IAcDepartmentService = IAcDepartmentService;
            _IAcStaffService = IAcStaffService;
            _IPuOrderService = IPuOrderService;
            _IQmCommodityService = IQmCommodityService;
            _IPrProductTaskService = IPrProductTaskService;
            _IQmProductService = IQmProductService;
            _IPuCommodityService = IPuCommodityService;
            _service = service;

            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入

        /// <summary>
        /// 获取所有待检商品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<QMPuOrderDtos>>> GetPO()
        //{
        //    var aa = (await _IPuOrderService.Search(u => u.Status==0)).ToList();
        //    return _IMapper.Map<List<QMPuOrderDtos>>(aa);
        //}
        public ActionResult<InfoResult<List<QMPuOrderDtos>>> GetPO(int pageSize = 15, int pageIndex = 1)
        {
            return new InfoResult<List<QMPuOrderDtos>>(_IMapper.Map<List<QMPuOrderDtos>> //Mapper转换
                (_IPuOrderService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => u.Status == 0, u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QMPuOrderDtos>>> GetPOID(int id)
        {
            var aa = (await _IPuOrderService.Search(u => u.Id == id && u.Status == 0)).ToList();
            return _IMapper.Map<List<QMPuOrderDtos>>(aa);
        }

        /// <summary>
        /// 获取所有商品信息(名称和id)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodity>>> GetALLPC()
        {
            //var aa = (await _IPuCommodityService.Search(u => true)).ToList();
            //return aa;
            var aa = (await _IPuCommodityService.Search(u => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<PuCommodity> ls = new List<PuCommodity>();
            aa.ForEach(u =>
            {
                ls.Add(new PuCommodity() { Id = u.Id, Name = u.Name });
            });
            return ls;
        }

        /// <summary>
        /// 获取所有员工信息(名称和id)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcStaff>>> GetALLACStaff()
        {
            var aa = (await _IAcStaffService.Search(u => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<AcStaff> ls = new List<AcStaff>();
            aa.ForEach(u =>
            {
                ls.Add(new AcStaff() { Id = u.Id, Name = u.Name });
            });
            return ls;
        }

        /// <summary>
        /// 获取待检商品信息(商品名称)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QMPuOrderDtos>>> GetPCID(int id)
        {
            var aa = (await _IPuOrderService.Search(u => u.CommodityId == id && u.Status == 0)).ToList();
            return _IMapper.Map<List<QMPuOrderDtos>>(aa);
        }

        /// <summary>
        /// 添加商品质检表的资料(合格不合格)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddQC(QmCommodity table)//此处不需要dtos传过来的操作人经手人都是id值
        {
            QmCommodity qm = new QmCommodity();
            qm.Id = int.Parse(table.No);
            qm.No = table.No;
            qm.OrderId = table.Id;
            qm.QmDate = table.QmDate;
            qm.Remark = table.Remark;
            qm.Pic = "";
            qm.OperateTime = DateTime.Now;
            qm.HandleId = Operator_id;
            qm.OperatorId = Operator_id;
            if (table.Result == 1)
            {
                qm.Result = 1;
                int bb = await _IQmCommodityService.Add(qm);
                PuOrder aa = (await _IPuOrderService.Search(u => u.No == Convert.ToString(table.OrderId))).FirstOrDefault();
                aa.Status = 2;
                aa.QmId = int.Parse(qm.No);
                int tt = await _IPuOrderService.Edit(aa);
                return bb;
            }
            else
            {
                qm.Result = 2;
                int bb = await _IQmCommodityService.Add(qm);
                PuOrder aa = (await _IPuOrderService.Search(u => u.No == Convert.ToString(table.OrderId))).FirstOrDefault();
                aa.Status = 1;
                aa.QmId = int.Parse(qm.No);
                int tt = await _IPuOrderService.Edit(aa);
                return bb;
            }
        }

        /// <summary>
        /// 获取所有质检商品信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<InfoResult<List<QmCommodityDtos>>> GetQC(int pageSize = 10, int pageIndex = 1)
        {
            return new InfoResult<List<QmCommodityDtos>>(_IMapper.Map<List<QmCommodityDtos>> //Mapper转换
                (_IQmCommodityService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => true, u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmCommodityDtos>>> GetPOIDTwo(int id)
        {
            var aa = (await _IQmCommodityService.Search(u => u.OrderId == id)).ToList();
            return _IMapper.Map<List<QmCommodityDtos>>(aa);
        }

        /// <summary>
        /// 获取质检商品信息(质检单编号)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmCommodityDtos>>> GetQCID(string id)
        {
            var aa = (await _IQmCommodityService.Search(u => u.No == id)).ToList();
            return _IMapper.Map<List<QmCommodityDtos>>(aa);
        }

        /// <summary>
        /// 获取所有质检单编号信息(id)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmCommodity>>> GetALLQCID()
        {
            //var aa = (await _IQmCommodityService.Search(u => true)).ToList();
            //return aa;
            var aa = (await _IQmCommodityService.Search(u => true)).Select(u => new { u.Id }).ToList();
            List<QmCommodity> ls = new List<QmCommodity>();
            aa.ForEach(u =>
            {
                ls.Add(new QmCommodity() { Id = u.Id });
            });
            return ls;
        }

        /// <summary>
        /// 获取所有待检产品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<QMPrProductTaskDtos>>> GetPPT()
        //{
        //    var aa = (await _IPrProductTaskService.Search(u => u.Status==0)).ToList();
        //    return _IMapper.Map<List<QMPrProductTaskDtos>>(aa);
        //}
        public ActionResult<InfoResult<List<QMPrProductTaskDtos>>> GetPPT(int pageSize = 10, int pageIndex = 1)
        {
            return new InfoResult<List<QMPrProductTaskDtos>>(_IMapper.Map<List<QMPrProductTaskDtos>> //Mapper转换
                (_IPrProductTaskService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => u.Status == 4, u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        /// <summary>
        /// 获取单条待检产品信息(生产单编号)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QMPrProductTaskDtos>>> GetPPTID(int id)
        {
            var aa = (await _IPrProductTaskService.Search(u => u.Id == id && u.Status == 4)).ToList();
            return _IMapper.Map<List<QMPrProductTaskDtos>>(aa);
        }

        /// <summary>
        /// 获取所有产品信息(名称和id)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PrProduct>>> GetALLPP()
        {
            var aa = (await _IPrProductService.Search(u => true)).Select(u => new { u.Id, u.Name }).ToList();
            List<PrProduct> ls = new List<PrProduct>();
            aa.ForEach(u =>
            {
                ls.Add(new PrProduct() { Id = u.Id, Name = u.Name });
            });
            return ls;
        }

        /// <summary>
        /// 获取待检产品信息(产品名称)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QMPrProductTaskDtos>>> GetPPID(int id)
        {
            var aa = (await _IPrProductTaskService.Search(u => u.ProductId == id && u.Status == 0)).ToList();
            return _IMapper.Map<List<QMPrProductTaskDtos>>(aa);
        }

        /// <summary>
        /// 添加产品质检表的资料(合格不合格)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddQP(QmProduct table)
        {
            QmProduct qm = new QmProduct();
            qm.Id = int.Parse(table.No);
            qm.No = table.No;
            qm.TaskId = table.Id;
            qm.QmDate = table.QmDate;
            qm.Remark = table.Remark;
            qm.Pic = "";
            qm.OperateTime = DateTime.Now;
            qm.HandleId = Operator_id;
            qm.OperatorId = Operator_id;
            if (table.Result == 1)
            {
                qm.Result = 1;
                int bb = await _IQmProductService.Add(qm);
                PrProductTask aa = (await _IPrProductTaskService.Search(u => u.No == Convert.ToString(table.TaskId))).FirstOrDefault();
                aa.Status = 2;
                aa.QmId = int.Parse(qm.No);
                int tt = await _IPrProductTaskService.Edit(aa);
                return bb;
            }
            else
            {
                qm.Result = 2;
                int bb = await _IQmProductService.Add(qm);
                PrProductTask aa = (await _IPrProductTaskService.Search(u => u.No == Convert.ToString(table.TaskId))).FirstOrDefault();
                aa.Status = 1;
                aa.QmId = int.Parse(qm.No);
                int tt = await _IPrProductTaskService.Edit(aa);
                return bb;
            }
        }

        /// <summary>
        /// 修改产品单表的资料(合格不合格后更改状态)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditPPTStatus(int? id)
        {
            //var puorder = _IPuOrderService.Search(u => u.Id == id);
            //puorder.Status = 2;
            PrProductTask pu = new PrProductTask();
            pu.No = Convert.ToString(id);
            pu.Status = 2;
            return await _IPrProductTaskService.Edit(pu);
        }

        /// <summary>
        /// 获取所有质检产品信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<InfoResult<List<QmProductDtos>>> GetQP(int pageSize = 10, int pageIndex = 1)
        {
            return new InfoResult<List<QmProductDtos>>(_IMapper.Map<List<QmProductDtos>> //Mapper转换
                (_IQmProductService.SearchByPage(//分页查询
                    pageSize, pageIndex, out int count, u => true, u => u.Id, false).ToList()))
            {
                Msg = count.ToString()
            };
        }

        /// <summary>
        /// 获取单条质检产品信息(生产单编号)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmProductDtos>>> GetPPTIDTwo(int id)
        {
            var aa = (await _IQmProductService.Search(u => u.TaskId == id)).ToList();
            return _IMapper.Map<List<QmProductDtos>>(aa);
        }

        /// <summary>
        /// 获取质检产品信息(质检单编号)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmProductDtos>>> GetQPID(string id)
        {
            var aa = (await _IQmProductService.Search(u => u.No == id)).ToList();
            return _IMapper.Map<List<QmProductDtos>>(aa);
        }

        /// <summary>
        /// 获取所有质检单编号信息(id)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QmProduct>>> GetALLQPID()
        {
            //var aa = (await _IQmProductService.Search(u => true)).ToList();
            //return aa;
            var aa = (await _IQmProductService.Search(u => true)).Select(u => new { u.Id }).ToList();
            List<QmProduct> ls = new List<QmProduct>();
            aa.ForEach(u =>
            {
                ls.Add(new QmProduct() { Id = u.Id });
            });
            return ls;
        }
    }
}