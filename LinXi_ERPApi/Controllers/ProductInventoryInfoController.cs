using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CustomerManageManage.DtoParameters;
using LinXi_Model.DTO.ProductInventory.Dtos;
using LinXi_Model.DTO.ProductionManagement.DtoParameters;
using LinXi_Model.DTO.ProductionManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 产品库存
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductInventoryInfoController : ControllerBase
    {
        #region 字段

        private IPrProductService _IPrProductService;
        private IPrProductTaskService _IPrProductTaskService;
        private IIcProductRecordService _IIcProductRecordService;
        private IAcUserinfoService _IAcUserinfoService;
        private IHttpContextAccessor _httpContext;
        private IAcStaffService _IAcStaffService;
        private ISlOrderService _ISlOrderService;
        private IAcDepartmentService _IAcDepartmentService;
        private readonly IMapper _mapper;

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

        #region 构造函数注入

        public ProductInventoryInfoController(
            IPrProductService ProductService,
            IIcProductRecordService IcProductRecordService,
            IPrProductTaskService PrProductTaskService,
            IAcUserinfoService AcUserinfoService,
              IHttpContextAccessor httpContextAccessor,
              IAcStaffService AcStaffService,
              ISlOrderService SlOrderService,
              IAcDepartmentService AcDepartmentService,
            IMapper mapper
            )
        {
            _IAcStaffService = AcStaffService;
            _IAcUserinfoService = AcUserinfoService;
            _httpContext = httpContextAccessor;
            _IIcProductRecordService = IcProductRecordService;
            _IPrProductService = ProductService;
            _IPrProductTaskService = PrProductTaskService;
            _ISlOrderService = SlOrderService;
            _IAcDepartmentService = AcDepartmentService;
            this._mapper = mapper;
        }

        #endregion 构造函数注入

        /// <summary>
        /// 获取操作人信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<AcStaff>> GetOperator()
        {
            int id = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
            var data = (await _IAcUserinfoService.Search(t => t.Id == id)).FirstOrDefault();
            var data2 = (await _IAcStaffService.Search(t => t.Id == data.StaffId)).FirstOrDefault();
            return Ok(data2);
        }

        /// <summary>
        /// 查询所有产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductStockDtos>>> GetAllProductInventory()
        {
            var productInfo = (await _IPrProductService.Search(t => true)).ToList();
            var data = _mapper.Map<IEnumerable<PrProductStockDtos>>(productInfo);
            return Ok(data);
        }

        /// <summary>
        /// 条件查询产品
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrProductStockDtos>>> CkeckSelectProductinfo([FromQuery] ProductDtosParameters productDtos)
        {
            var productInfo = (await _IPrProductService.Search(t => true)).ToList();
            var data = _mapper.Map<IEnumerable<PrProductStockDtos>>(productInfo);
            if (!string.IsNullOrWhiteSpace(productDtos.name))
            {
                switch (productDtos.select)
                {
                    case 1:
                        {
                            var product = data.Where(t => t.CategoryName.Contains(productDtos.name)).ToList();
                            return Ok(product);
                        }

                    case 2:
                        {
                            var product = data.Where(t => t.Name.Contains(productDtos.name)).ToList();
                            return Ok(product);
                        }
                }
            }
            return Ok(data);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="delList"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<PrProductStockDtos>>> DeleteProductinfo(List<PrProductStockDtos> delList)
        {
            int data = 0;
            InfoResult<PrProductStockDtos> messageModel = new InfoResult<PrProductStockDtos>();
            foreach (var item in delList)
            {
                try
                {
                    data = await _IPrProductService.Delete(_mapper.Map<PrProduct>(item));
                }
                catch
                {
                    messageModel.Success = false;
                    messageModel.Code = 201;
                    messageModel.Msg = "删除失败!";
                    return Ok(messageModel);
                }
            }
            if (data > 0)
            {
                messageModel.Code = 400;
                messageModel.Success = true;
                messageModel.Msg = "删除成功";
            }
            else
            {
                messageModel.Code = 400;
                messageModel.Success = false;
                messageModel.Msg = "删除失败!";
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 查询所有未入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcductTaskDtos>>> GetAllProductPutinStorage()
        {
            var data2 = (await _IPrProductTaskService.Search(t => t.Status == 2)).ToList();
            var data = _mapper.Map<List<ProcductTaskDtos>>(data2);
            foreach (var item in data)
            {
                if (item.Status == 2)
                {
                    item.StatusName = "未入库";
                }
            }
            return Ok(data);
        }

        /// <summary>
        /// 获取最新出入库ID
        /// </summary>
        [HttpGet]
        public async Task<int> getIcProductRecordID()
        {
            var cusList = await _IIcProductRecordService.Search(t => true);
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
        /// 获取部门信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDepartment>>> getAcDepartment()
        {
            var productInfo = (await _IAcDepartmentService.Search(t => true)).ToList();
            var data = _mapper.Map<IEnumerable<AcDepartment>>(productInfo);
            return Ok(data);
        }

        /// <summary>
        /// 模糊查询未入库单
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcductTaskDtos>>> CkeckSelectProducTasktinfo([FromQuery] ProcductTaskDtosParameters check)
        {
            var productInfo = (await _IPrProductTaskService.Search(t => t.Status == 2)).ToList();
            var data = _mapper.Map<IEnumerable<ProcductTaskDtos>>(productInfo);
            foreach (var item in data)
            {
                if (item.Status == 2)
                {
                    item.StatusName = "未入库";
                }
            }
            if (!string.IsNullOrWhiteSpace(check.name))
            {
                switch (check.select)
                {
                    case 1:
                        {
                            var product = data.Where(t => t.Category.Contains(check.name)).ToList();
                            return Ok(product);
                        }

                    case 2:
                        {
                            var product = data.Where(t => t.Name.Contains(check.name)).ToList();
                            return Ok(product);
                        }
                }
            }
            return Ok(data);
        }

        /// <summary>
        /// 产品入库
        /// </summary>
        /// <param name="procductRecordDtos"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<ProcductTaskDtos>>> ProductPutInStorage(PrProductTask productrecord)
        {
            var z = Operator_id;
            int id = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
            var data = (await _IAcUserinfoService.Search(t => t.Id == id)).FirstOrDefault();
            var data2 = (await _IAcStaffService.Search(t => t.Id == data.StaffId)).FirstOrDefault();
            var cusList = await _IIcProductRecordService.Search(t => true);
            int max = 0;
            foreach (var item in cusList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            int Id = max + 1;
            IcProductRecord ic = new IcProductRecord()
            {
                Id = Id,
                Name = "入库",
                IsIn = 0,
                SourceCategory = 0,
                SourceId = productrecord.Id,
                SourceNo = productrecord.No,
                ProductId = productrecord.ProductId,
                Batch = productrecord.Batch,
                Nums = productrecord.Nums,
                Reason = productrecord.Remark,
                DepartmentId = productrecord.DepartmentId,
                StaffId = productrecord.OperatorId,
                WarehouseId = 1,
                OperatorId = data2.Id,
                OperateTime = productrecord.OperateTime,
                Status = 1,
            };
            var data3 = await _IIcProductRecordService.Add(ic);
            productrecord.Status = 3;
            var data4 = await _IPrProductTaskService.Edit(productrecord);
            PrProduct product = (await _IPrProductService.Search(t => t.Id == productrecord.ProductId)).FirstOrDefault();
            product.Stock += productrecord.Nums;
            var data5 = await _IPrProductService.Edit(product);
            InfoResult<ProcductTaskDtos> messageModel = new InfoResult<ProcductTaskDtos>();
            if (data3 > 0 && data4 > 0)
            {
                messageModel.Msg = "入库成功！";
                messageModel.Code = 400;
                messageModel.Success = true;
            }
            else if (data3 > 0)
            {
                messageModel.Msg = "入库失败！";
                messageModel.Code = 201;
                messageModel.Success = false;
            }
            else
            {
                messageModel.Msg = "添加失败！";
                messageModel.Code = 201;
                messageModel.Success = false;
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 查询所有入库单
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRecordDtos>>> SelectAllPutInList()
        {
            var productInfo = (await _IIcProductRecordService.Search(t => t.IsIn == 0)).Select(u => new { u.Id, u.Name, u.IsIn, u.SourceCategory, u.SourceId, u.SourceNo, u.ProductId, u.Batch, u.Nums, u.Reason, u.DepartmentId, u.StaffId, u.WarehouseId, u.OperatorId, u.OperateTime, u.Status, u.Remark, u.Department, u.Product, u.Staff, u.Operator }).ToList();
            var ls = new List<ProductRecordDtos>();
            foreach (var item in productInfo)
            {
                ls.Add(new ProductRecordDtos() { Id = item.Id, Name = item.Name, IsIn = item.IsIn, SourceCategory = item.SourceCategory, SourceId = item.SourceId, SourceNo = item.SourceNo, ProductId = item.ProductId, Batch = item.Batch, Nums = item.Nums, Reason = item.Reason, DepartmentId = item.DepartmentId, StaffId = item.StaffId, WarehouseId = item.WarehouseId, OperatorId = item.OperatorId, OperateTime = item.OperateTime, Status = item.Status, Remark = item.Remark, StaffName = item.Staff.Name, DepartentName = item.Department.Name, OperatorName = item.Operator.Name, ProductName = item.Product.Name });
            }
            return ls;
        }

        /// <summary>
        /// 模糊查询入库单
        /// </summary>
        /// <param name="procducttaskDtos"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRecordDtos>>> CheckSelectPutInInfo([FromQuery] ProcductTaskDtosParameters procducttaskDtos)
        {
            var productInfo = (await _IIcProductRecordService.Search(t => t.IsIn == 0)).Select(u => new { u.Id, u.Name, u.IsIn, u.SourceCategory, u.SourceId, u.SourceNo, u.ProductId, u.Batch, u.Nums, u.Reason, u.DepartmentId, u.StaffId, u.WarehouseId, u.OperatorId, u.OperateTime, u.Status, u.Remark, u.Department, u.Product, u.Staff, u.Operator }).ToList();

            var ls = new List<ProductRecordDtos>();
            foreach (var item in productInfo)
            {
                ls.Add(new ProductRecordDtos() { Id = item.Id, Name = item.Name, IsIn = item.IsIn, SourceCategory = item.SourceCategory, SourceId = item.SourceId, SourceNo = item.SourceNo, ProductId = item.ProductId, Batch = item.Batch, Nums = item.Nums, Reason = item.Reason, DepartmentId = item.DepartmentId, StaffId = item.StaffId, WarehouseId = item.WarehouseId, OperatorId = item.OperatorId, OperateTime = item.OperateTime, Status = item.Status, Remark = item.Remark, StaffName = item.Staff.Name, DepartentName = item.Department.Name, OperatorName = item.Operator.Name, ProductName = item.Product.Name });
            }
            if (!string.IsNullOrWhiteSpace(procducttaskDtos.name))
            {
                switch (procducttaskDtos.select)
                {
                    case 1:
                        {
                            var product = ls.Where(t => t.Id.ToString().Contains(procducttaskDtos.name)).ToList();
                            return Ok(product);
                        }

                    case 2:
                        {
                            var product = ls.Where(t => t.ProductName.Contains(procducttaskDtos.name)).ToList();
                            return Ok(product);
                        }
                }
            }
            return Ok(ls);
        }

        /// <summary>
        /// 查询所有未出库单
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderDtos>>> SelectAllGetOut()
        {
            var productInfo = (await _ISlOrderService.Search(t => t.Status == 2)).Select(u => new { u.Id, u.No, u.CustomerId, u.ProductId, u.Nums, u.Price, u.DeliveryDate, u.DeliveryWay, u.OrderDate, u.OrderAmount, u.HandleId, u.OperatorId, u.OperatorTime, u.Status, u.Remark, u.Product, u.Handle }).ToList();
            var ls = new List<SlOrderDtos>();
            foreach (var item in productInfo)
            {
                ls.Add(new SlOrderDtos() { Id = item.Id, No = item.No, CustomerId = item.CustomerId, ProductId = item.ProductId, Nums = item.Nums, Price = item.Price, DeliveryDate = item.DeliveryDate, DeliveryWay = item.DeliveryWay, OrderAmount = item.OrderAmount, HandleId = item.HandleId, OperatorId = item.OperatorId, OperatorTime = item.OperatorTime, Status = item.Status, Remark = item.Remark, ProductName = item.Product.Name, HandleName = item.Handle.Name, unit = item.Product.Unit, stock = item.Product.Stock, Productprice = item.Product.Price, spec = item.Product.Spec, OperatorName = item.Handle.Name });
            }

            return ls;
        }

        /// <summary>
        /// 模糊查询未出库单
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderDtos>>> CheckSelectGetOut([FromQuery] ProcductTaskDtosParameters procducttaskDtos)
        {
            var productInfo = (await _ISlOrderService.Search(t => t.Status == 2)).Select(u => new { u.Id, u.No, u.CustomerId, u.ProductId, u.Nums, u.Price, u.DeliveryDate, u.DeliveryWay, u.OrderDate, u.OrderAmount, u.HandleId, u.OperatorId, u.OperatorTime, u.Status, u.Remark, u.Product, u.Handle }).ToList();
            var ls = new List<SlOrderDtos>();
            foreach (var item in productInfo)
            {
                ls.Add(new SlOrderDtos() { Id = item.Id, No = item.No, CustomerId = item.CustomerId, ProductId = item.ProductId, Nums = item.Nums, Price = item.Price, DeliveryDate = item.DeliveryDate, DeliveryWay = item.DeliveryWay, OrderAmount = item.OrderAmount, HandleId = item.HandleId, OperatorId = item.OperatorId, OperatorTime = item.OperatorTime, Status = item.Status, Remark = item.Remark, ProductName = item.Product.Name, HandleName = item.Handle.Name, unit = item.Product.Unit, stock = item.Product.Stock, Productprice = item.Product.Price, spec = item.Product.Spec, OperatorName = item.Handle.Name });
            }
            if (!string.IsNullOrWhiteSpace(procducttaskDtos.name))
            {
                switch (procducttaskDtos.select)
                {
                    case 1:
                        {
                            var product = ls.Where(t => t.No.Contains(procducttaskDtos.name)).ToList();
                            return Ok(product);
                        }

                    case 2:
                        {
                            var product = ls.Where(t => t.ProductName.Contains(procducttaskDtos.name)).ToList();
                            return Ok(product);
                        }
                }
            }
            return Ok(ls);
        }

        /// <summary>
        /// 产品出库
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<InfoResult<SlOrder>>> ProductGetOutStorage(int ID, SlOrder SlOrder)
        {
            int id = int.Parse(_httpContext.HttpContext.User.FindFirst("operator_id").Value);
            var data = (await _IAcUserinfoService.Search(t => t.Id == id)).FirstOrDefault();
            var data2 = (await _IAcStaffService.Search(t => t.Id == data.StaffId)).FirstOrDefault();
            var cusList = await _IIcProductRecordService.Search(t => true);
            int max = 0;
            foreach (var item in cusList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            int putinId = max + 1;
            IcProductRecord ic = new IcProductRecord()
            {
                Id = putinId,
                Name = "出库",
                IsIn = 1,
                SourceCategory = 1,
                SourceId = SlOrder.Id,
                SourceNo = SlOrder.No,
                ProductId = SlOrder.ProductId,
                Batch = "",
                Nums = SlOrder.Nums,
                Reason = SlOrder.Remark,
                DepartmentId = ID,
                StaffId = SlOrder.OperatorId,
                WarehouseId = 1,
                OperatorId = data2.Id,
                OperateTime = DateTime.Now,
                Status = 2,
            };
            var data3 = await _IIcProductRecordService.Add(ic);
            SlOrder.Status = 3;
            var data4 = await _ISlOrderService.Edit(SlOrder);
            PrProduct product = (await _IPrProductService.Search(t => t.Id == SlOrder.ProductId)).FirstOrDefault();
            product.Stock += SlOrder.Nums;
            var data5 = await _IPrProductService.Edit(product);
            InfoResult<SlOrder> messageModel = new InfoResult<SlOrder>();
            if (data3 > 0 && data4 > 0)
            {
                messageModel.Msg = "出库成功！";
                messageModel.Code = 400;
                messageModel.Success = true;
            }
            else if (data3 > 0)
            {
                messageModel.Msg = "出库失败！";
                messageModel.Code = 201;
                messageModel.Success = false;
            }
            else
            {
                messageModel.Msg = "添加失败！";
                messageModel.Code = 201;
                messageModel.Success = false;
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 查询所有出库单
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRecordDtos>>> GetSlectAllGetOutInfo()
        {
            var productInfo = (await _IIcProductRecordService.Search(t => t.IsIn == 0)).Select(u => new { u.Id, u.Name, u.IsIn, u.SourceCategory, u.SourceId, u.SourceNo, u.ProductId, u.Batch, u.Nums, u.Reason, u.DepartmentId, u.StaffId, u.WarehouseId, u.OperatorId, u.OperateTime, u.Status, u.Remark, u.Department, u.Product, u.Staff, u.Operator }).ToList();

            var ls = new List<ProductRecordDtos>();
            foreach (var item in productInfo)
            {
                ls.Add(new ProductRecordDtos() { Id = item.Id, Name = item.Name, IsIn = item.IsIn, SourceCategory = item.SourceCategory, SourceId = item.SourceId, SourceNo = item.SourceNo, ProductId = item.ProductId, Batch = item.Batch, Nums = item.Nums, Reason = item.Reason, DepartmentId = item.DepartmentId, StaffId = item.StaffId, WarehouseId = item.WarehouseId, OperatorId = item.OperatorId, OperateTime = item.OperateTime, Status = item.Status, Remark = item.Remark, StaffName = item.Staff.Name, DepartentName = item.Department.Name, OperatorName = item.Operator.Name, ProductName = item.Product.Name });
            }
            return ls;
        }

        /// <summary>
        /// 模糊查询出库单
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IcProductRecord>>> CheckSelectGetOutInfo([FromQuery] ProcductTaskDtosParameters procducttaskDtos)
        {
            var productInfo = (await _IIcProductRecordService.Search(t => t.IsIn == 0)).Select(u => new { u.Id, u.Name, u.IsIn, u.SourceCategory, u.SourceId, u.SourceNo, u.ProductId, u.Batch, u.Nums, u.Reason, u.DepartmentId, u.StaffId, u.WarehouseId, u.OperatorId, u.OperateTime, u.Status, u.Remark, u.Department, u.Product, u.Staff, u.Operator }).ToList();

            var ls = new List<ProductRecordDtos>();
            foreach (var item in productInfo)
            {
                ls.Add(new ProductRecordDtos() { Id = item.Id, Name = item.Name, IsIn = item.IsIn, SourceCategory = item.SourceCategory, SourceId = item.SourceId, SourceNo = item.SourceNo, ProductId = item.ProductId, Batch = item.Batch, Nums = item.Nums, Reason = item.Reason, DepartmentId = item.DepartmentId, StaffId = item.StaffId, WarehouseId = item.WarehouseId, OperatorId = item.OperatorId, OperateTime = item.OperateTime, Status = item.Status, Remark = item.Remark, StaffName = item.Staff.Name, DepartentName = item.Department.Name, OperatorName = item.Operator.Name, ProductName = item.Product.Name });
            }
            if (!string.IsNullOrWhiteSpace(procducttaskDtos.name))
            {
                switch (procducttaskDtos.select)
                {
                    case 1:
                        {
                            var product = ls.Where(t => t.Id.ToString().Contains(procducttaskDtos.name)).ToList();
                            return Ok(product);
                        }
                    case 2:
                        {
                            var product = ls.Where(t => t.SourceNo.Contains(procducttaskDtos.name)).ToList();
                            return Ok(product);
                        }
                }
            }
            return Ok(ls);
        }
    }
}