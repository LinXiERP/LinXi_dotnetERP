using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CommodityInventory.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 商品库存管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommodityInventoryController : ControllerBase
    {
        private ILogger<CommodityInventoryController> _logger;

        private IPuCommodityServicce _IPuCommodityServicce;
        private IPuCommodityCategoryService _IPuCommodityCategoryService;
        private IPuOrderService _IPuOrderService;
        private IIcCommodityRecordService _IIcCommodityRecordService;
        private IServiceProvider _service;
        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;
        private IPrProductMaterialService _IPrProductMaterialService;
        private IAcUserinfoService _IAcUserinfoService;
        private IAcStaffService _IAcStaffService;
        private IAcDepartmentService _AcDepartmentService;

        #region 构造函数注入

        public CommodityInventoryController(ILogger<CommodityInventoryController> logger,
            IPuCommodityServicce IPuCommodityServicce,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor,
            IPuCommodityCategoryService IPuCommodityCategoryService,
            IPuOrderService IPuOrderService,
            IIcCommodityRecordService IIcCommodityRecordService,
            IPrProductMaterialService IPrProductMaterialService,
            IAcUserinfoService IAcUserinfoService,
            IAcStaffService IAcStaffService,
            IAcDepartmentService IAcDepartment

            )
        {
            _logger = logger;
            _IPuCommodityServicce = IPuCommodityServicce;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
            _IPuCommodityCategoryService = IPuCommodityCategoryService;
            _IPuOrderService = IPuOrderService;
            _IIcCommodityRecordService = IIcCommodityRecordService;
            _IPrProductMaterialService = IPrProductMaterialService;
            _IAcUserinfoService = IAcUserinfoService;
            _IAcStaffService = IAcStaffService;
            _AcDepartmentService = IAcDepartment;
        }

        #endregion 构造函数注入

        /// <summary>
        /// 操作人信息
        /// </summary>

        [HttpGet]
        public async Task<ActionResult<AcStaff>> GetOperator()
        {
            int id = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
            var data = (await _IAcUserinfoService.Search(u => u.Id == id)).Select(u => u.Id).FirstOrDefault();
            var data2 = (await _IAcStaffService.Search(u => u.Id == data)).Select(u => new { u.Id, u.Name });
            return Ok(data2.FirstOrDefault());
        }

        /// <summary>
        /// 全部商品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodity>>> GetPuCommodityInfo()
        {
            var data = (await _IPuCommodityServicce.Search(t => true)).ToList();
            var data2 = _IMapper.Map<List<CPuCommodityDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 筛选商品信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodity>>> ScreenPuCommodityInfo(string name, int category)
        {
            var data = (await _IPuCommodityServicce.Search(t => t.Name == name && t.CategoryId == category)).ToList();
            if (name != null && category.ToString() == null)
            {
                data = (await _IPuCommodityServicce.Search(t => t.Name == name)).ToList();
            }
            else
            {
                data = (await _IPuCommodityServicce.Search(t => t.CategoryId == category)).ToList();
            }

            var data2 = _IMapper.Map<List<CPuCommodityDtos>>(data);

            return Ok(data2);
        }

        /// <summary>
        /// 获取商品类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuCommodityCategoryDtos>>> GetCategoryInfo()
        {
            var data = (await _IPuCommodityCategoryService.Search(t => true)).ToList();
            var data2 = _IMapper.Map<List<PuCommodityCategoryDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<InfoResult<CPuCommodityDtos>>> DeleteCommodity(int[] data)
        {
            int a = 0;
            CPuCommodityDtos puCommodityDtos = new CPuCommodityDtos();

            InfoResult<CPuCommodityDtos> messageModel = new InfoResult<CPuCommodityDtos>();

            foreach (var item in data)
            {
                var result = await _IPuCommodityServicce.FindAsyncById(item);
                a += await _IPuCommodityServicce.Delete(result);
            }
            if (a == data.Length)
            {
                messageModel.Code = 400;
                messageModel.Success = true;
                messageModel.Msg = "删除成功";
            }
            else
            {
                messageModel.Code = 200;
                messageModel.Success = false;
                messageModel.Msg = "删除失败!";
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 采购单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommodityOrderDtos>>> GetPuOreders()
        {
            var data = (await _IPuOrderService.Search(t => t.Status == 4)).ToList();
            var data2 = _IMapper.Map<IEnumerable<CommodityOrderDtos>>(data);

            return Ok(data2);
        }

        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="iCCommodityRecordDtos"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InfoResult<ICCommodityRecordDtos>>> AddInICommodityRecord(ICCommodityRecordDtos iCCommodityRecordDtos)
        {
            var result = _IMapper.Map<IcCommodityRecord>(iCCommodityRecordDtos);
            var data = await _IIcCommodityRecordService.Add(result);
            PuOrder data2 = (await _IPuOrderService.Search(t => t.Id == result.SourceId)).FirstOrDefault();

            data2.Status = 5;
            var data3 = await _IPuOrderService.Edit(data2);

            PuCommodity data4 = (await _IPuCommodityServicce.Search(t => t.Id == result.CommodityId)).FirstOrDefault();
            data4.Stock = data4.Stock + result.Nums;
            var data5 = await _IPuCommodityServicce.Edit(data4);
            InfoResult<ICCommodityRecordDtos> messageModel = new InfoResult<ICCommodityRecordDtos>();
            if (data > 0 && data3 > 0) { messageModel.Msg = "入库成功！"; messageModel.Code = 400; messageModel.Success = true; }
            else if (data > 0)
            {
                messageModel.Msg = "入库失败！"; messageModel.Code = 201; messageModel.Success = false;

                var Id = (await _IIcCommodityRecordService.Search(testc => true)).Max(z => z.Id);
                var data7 = await _IIcCommodityRecordService.Search(t => t.Id == Id);
                await _IIcCommodityRecordService.Delete((IcCommodityRecord)data7);
            }
            else
            {
                messageModel.Msg = "添加失败！"; messageModel.Code = 201; messageModel.Success = false;
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 获取出入库最新ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> getCommodityRecordID()
        {
            var cusList = await _IIcCommodityRecordService.Search(t => true);
            int max = 0;
            foreach (var item in cusList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            int Id = max + 1;
            return Id;
        }

        /// <summary>
        /// 查询采购订单
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuOrderDtos>>> searchPuOrder(string name, int category)
        {
            var data = (await _IPuOrderService.Search(t => (t.Commodity.Name == name && t.Commodity.CategoryId == category) || (t.Commodity.Supplier.Name == name && t.Commodity.CategoryId == category))).ToList();
            var data2 = _IMapper.Map<List<PuOrderDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 获取入库单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICCommodityRecordDtos>>> GetIcCommoditRecord()
        {
            var data = (await _IIcCommodityRecordService.Search(t => t.IsIn == 0)).Select(u => new { u.Id, u.Name, u.IsIn, u.SourceCategory, u.SourceId, u.SourceNo, u.CommodityId, u.Batch, u.Nums, u.Reason, u.DepartmentId, u.StaffId, u.WarehouseId, u.OperatorId, u.OperateTime, u.Status, u.Remark, u.Commodity, u.Staff }).ToList();
            var ls = new List<ICCommodityRecordDtos>();
            foreach (var item in data)
            {
                ls.Add(new ICCommodityRecordDtos() { Id = item.Id, Name = item.Name, Isin = item.IsIn, Sourcecategory = item.SourceCategory, Sourceid = item.SourceId, Sourceno = item.SourceNo, Commodityid = item.CommodityId, Batch = item.Batch, Nums = item.Nums, Reason = item.Reason, Departmentid = item.DepartmentId, Staffid = item.StaffId, Warehouseid = item.WarehouseId, Operatorid = item.OperatorId, OperateTime = item.OperateTime, Status = item.Status, Remark = item.Remark, CommodityName = item.Commodity.Name, StaffName = item.Staff.Name });
            }
            return ls;
        }

        /// <summary>
        /// 出库单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICCommodityRecordDtos>>> GetOutCommodityRecordDtos()
        {
            var data = (await _IIcCommodityRecordService.Search(t => t.IsIn == 1)).Select(u => new { u.Id, u.Name, u.IsIn, u.SourceCategory, u.SourceId, u.SourceNo, u.CommodityId, u.Batch, u.Nums, u.Reason, u.DepartmentId, u.StaffId, u.WarehouseId, u.OperatorId, u.OperateTime, u.Status, u.Remark, u.Commodity, u.Staff }).ToList();
            var ls = new List<ICCommodityRecordDtos>();
            foreach (var item in data)
            {
                ls.Add(new ICCommodityRecordDtos() { Id = item.Id, Name = item.Name, Isin = item.IsIn, Sourcecategory = item.SourceCategory, Sourceid = item.SourceId, Sourceno = item.SourceNo, Commodityid = item.CommodityId, Batch = item.Batch, Nums = item.Nums, Reason = item.Reason, Departmentid = item.DepartmentId, Staffid = item.StaffId, Operatorid = item.OperatorId, OperateTime = item.OperateTime, Status = item.Status, Remark = item.Remark, CommodityName = item.Commodity.Name, StaffName = item.Staff.Name });
            }
            return ls;
        }

        /// <summary>
        /// 获取领料单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPrProductMaterialDtos>>> GetPrProductMaterial()
        {
            var data = (await _IPrProductMaterialService.Search(t => t.Status == 0)).ToList();
            var data2 = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CAcDepartmentDtos>>> Getdepartment()
        {
            var data = _IMapper.Map<IEnumerable<CAcDepartmentDtos>>((await _AcDepartmentService.Search(t => true)).ToList());
            return Ok(data);
        }

        /// <summary>
        /// 查询领料单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depatmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPrProductMaterialDtos>>> searchPrProductMaterial(int id, int depatmentId)
        {
            if (depatmentId == 0 && id != 0)
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IPrProductMaterialService.Search(t => t.Status == 1 && t.Id == id)).ToList());
                return Ok(data);
            }
            else if (depatmentId != 0 && id == 0)
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IPrProductMaterialService.Search(t => t.Status == 1 && t.DepartmentId == depatmentId)).ToList());
                return Ok(data);
            }
            else
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IPrProductMaterialService.Search(t => t.Status == 1 && t.Id == id && t.DepartmentId == depatmentId)).ToList());
                return Ok(data);
            }
        }

        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="iCCommodityRecordDtos"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InfoResult<ICCommodityRecordDtos>>> AddOutICommodityRecord(ICCommodityRecordDtos iCCommodityRecordDtos)
        {
            var result = _IMapper.Map<IcCommodityRecord>(iCCommodityRecordDtos);
            PuCommodity data4 = (await _IPuCommodityServicce.Search(t => t.Id == result.CommodityId)).FirstOrDefault();
            InfoResult<ICCommodityRecordDtos> messageModel = new InfoResult<ICCommodityRecordDtos>();

            if (data4.Stock > result.Nums)
            {
                var data = await _IIcCommodityRecordService.Add(result);
                PrProductMaterial data2 = (await _IPrProductMaterialService.Search(t => t.Id == result.SourceId)).FirstOrDefault();
                data2.Status = 2;
                var data3 = await _IPrProductMaterialService.Edit(data2);

                data4.Stock = data4.Stock - result.Nums;
                var data5 = await _IPuCommodityServicce.Edit(data4);
                if (data > 0 && data3 > 0) { messageModel.Msg = "出库成功！"; messageModel.Code = 400; messageModel.Success = true; }
                else if (data > 0)
                {
                    messageModel.Msg = "出库失败！"; messageModel.Code = 201; messageModel.Success = false;
                    var Id = (await _IIcCommodityRecordService.Search(testc => true)).Max(z => z.Id);
                    var data7 = await _IIcCommodityRecordService.Search(t => t.Id == Id);
                    await _IIcCommodityRecordService.Delete((IcCommodityRecord)data7);
                }
                else
                {
                    messageModel.Msg = "出库失败！"; messageModel.Code = 201; messageModel.Success = false;
                }
            }
            else
            {
                messageModel.Msg = "出库失败！库存不足"; messageModel.Code = 201; messageModel.Success = false;
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 查询入库单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sourceno"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICCommodityRecordDtos>>> SearchInRecord(int id, string sourceno)
        {
            if (sourceno == "" && id != 0)
            {
                var data = _IMapper.Map<IEnumerable<ICCommodityRecordDtos>>((await _IIcCommodityRecordService.Search(t => t.IsIn == 0 && t.Id == id)).ToList());
                return Ok(data);
            }
            else if (sourceno != "" && id == 0)
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IIcCommodityRecordService.Search(t => t.IsIn == 0 && t.SourceNo == sourceno)).ToList());
                return Ok(data);
            }
            else
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IIcCommodityRecordService.Search(t => t.IsIn == 0 && t.Id == id && t.SourceNo == sourceno)).ToList());
                return Ok(data);
            }
        }

        /// <summary>
        /// 查询出库单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sourceno"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ICCommodityRecordDtos>>> SearchOutRecord(int id, string sourceno)
        {
            if (sourceno == "" && id != 0)
            {
                var data = _IMapper.Map<IEnumerable<ICCommodityRecordDtos>>((await _IIcCommodityRecordService.Search(t => t.IsIn == 1 && t.Id == id)).ToList());
                return Ok(data);
            }
            else if (sourceno != "" && id == 0)
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IIcCommodityRecordService.Search(t => t.IsIn == 1 && t.SourceNo == sourceno)).ToList());
                return Ok(data);
            }
            else
            {
                var data = _IMapper.Map<IEnumerable<CPrProductMaterialDtos>>((await _IIcCommodityRecordService.Search(t => t.IsIn == 1 && t.Id == id && t.SourceNo == sourceno)).ToList());
                return Ok(data);
            }
        }
    }
}