using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CustomerManageManage.DtoParameters;
using LinXi_Model.DTO.CustomerManageManage.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]

    public class CustomerManagementController : ControllerBase
    {
        #region 依赖注入
        private readonly ISlCustomerService _slCustomerService;
        private readonly ISlOrderService _slOrderService;
        private readonly IPrProductService _prProductService;
        private readonly IAcUserinfoService _acUserinfoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private int UserId
        {
            get
            {
                return int.Parse(_httpContextAccessor.HttpContext.User.Claims.Where(u => u.Type == "UserId").FirstOrDefault().Value);
            }
        }



        public CustomerManagementController(ISlCustomerService slCustomerService, ISlOrderService slOrderService,IPrProductService prProductService,IAcUserinfoService acUserinfoService, IHttpContextAccessor httpContextAccessor,IMapper mapper)
        {
            this._slCustomerService = slCustomerService;
            this._slOrderService = slOrderService;
            this._prProductService = prProductService;
            this._acUserinfoService = acUserinfoService;
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
        }

        #endregion


        #region 客户信息管理
        /// <summary>
        /// 获取所有的客户信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlCustomerDtos>>> GetAllCustomerInfo()
        {
            var data = _mapper.Map<IEnumerable<SlCustomerDtos>>(await _slCustomerService.Search(t => true));
            return Ok(data);
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<InfoResult<SlCustomerDtos>>> DeleteCustomerInfo(int id)
        {
            SlCustomerDtos slCustomerDtos = new SlCustomerDtos();
            slCustomerDtos.Id = id;

            InfoResult<SlCustomerDtos> messageModel = new InfoResult<SlCustomerDtos>();
            int data = 0;
            try
            {
                data = await _slCustomerService.Delete(_mapper.Map<SlCustomer>(slCustomerDtos));
            }
            catch
            {
                messageModel.Success = false;
                messageModel.Code = 201;
                messageModel.Msg = "删除失败!";
                return Ok(messageModel);
            }
            if (data > 0)
            {
                messageModel.Code = 200;
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
        /// 修改客户信息
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<InfoResult<SlCustomerDtos>>> UpdateCustomerInfo(SlCustomerDtos slCustomerDtos)
        {
            var data = await _slCustomerService.Edit(_mapper.Map<SlCustomer>(slCustomerDtos));
            InfoResult<SlCustomerDtos> messageModel = new InfoResult<SlCustomerDtos>();
            if (data > 0) { messageModel.Msg = "更新成功"; messageModel.Code = 200; messageModel.Success = true; }
            else
            {
                messageModel.Msg = "更新失败"; messageModel.Code = 400; messageModel.Success = false;
            }
            return Ok(messageModel);
        }


        /// <summary>
        /// 添加客户信息
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<InfoResult<SlCustomerDtos>>> AddCustomerInfo(SlCustomerDtos slCustomerDtos)
        {
            var cusList = await _slCustomerService.Search(t => true);
            int max = 0;
            foreach (var item in cusList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            slCustomerDtos.Id = max + 1;
            var data = await _slCustomerService.Add(_mapper.Map<SlCustomer>(slCustomerDtos));
            InfoResult<SlCustomerDtos> messageModel = new InfoResult<SlCustomerDtos>();
            if (data > 0) { messageModel.Msg = "添加成功！"; messageModel.Code = 200; messageModel.Success = true; }
            else
            {
                messageModel.Msg = "添加失败！"; messageModel.Code = 400; messageModel.Success = false;
            }
            return Ok(messageModel);
        }


        /// <summary>
        /// 过滤搜索客户信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlCustomerDtos>>> SelectCustomerInfo([FromQuery] CustomerDtosParameters customerDtosParameters)
        {
            IEnumerable<SlCustomer> list = _mapper.Map<IEnumerable<SlCustomer>>(await _slCustomerService.Search(t => true));
            if (!string.IsNullOrWhiteSpace(customerDtosParameters.name))
            {
                switch (customerDtosParameters.select)
                {
                    case 1:
                        {
                            var data = list.Where(t => t.Name.Contains(customerDtosParameters.name)).ToList();
                            return Ok(data);
                        }

                    case 2:
                        {
                            var data = list.Where(t => t.Custtel.Contains(customerDtosParameters.name)).ToList();
                            return Ok(data);
                        }
                    case 3:
                        {
                            var data = list.Where(t => t.Linkman.Contains(customerDtosParameters.name)).ToList();
                            return Ok(data);
                        }
                }
            }
            return Ok(list);

        }
        #endregion

        #region 订单管理
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlOrderDots>>> GetAllCustomerOrder()
        {
            var data2 = (await _slOrderService.Search(t => true)).ToList();
            var data = _mapper.Map<List<SlOrderDots>>(data2);
            return Ok(data);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<InfoResult<SlCustomerDtos>>> DeleteCustomerOrder(int id)
        {
            SlCustomerDtos slCustomerDtos = new SlCustomerDtos();
            slCustomerDtos.Id = id;

            InfoResult<SlCustomerDtos> messageModel = new InfoResult<SlCustomerDtos>();
            int data = 0;
            try
            {
                data = await _slCustomerService.Delete(_mapper.Map<SlCustomer>(slCustomerDtos));
            }
            catch
            {
                messageModel.Success = false;
                messageModel.Code = 400;
                messageModel.Msg = "删除失败!";
                return Ok(messageModel);
            }
            if (data > 0)
            {
                messageModel.Code = 200;
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
        /// 修改订单信息
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<InfoResult<SlCustomerDtos>>> UpdateCustomerOrder(SlOrderDots slOrderDots)
        {
            var data = await _slOrderService.Edit(_mapper.Map<SlOrder>(slOrderDots));
            InfoResult<SlCustomerDtos> messageModel = new InfoResult<SlCustomerDtos>();
            if (data > 0) { messageModel.Msg = "更新成功"; messageModel.Code = 200; messageModel.Success = true; }
            else
            {
                messageModel.Msg = "更新失败"; messageModel.Code = 400; messageModel.Success = false;
            }
            return Ok(messageModel);
        }


        /// <summary>
        /// 添加订单信息
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<InfoResult<SlOrderDots>>> AddCustomerOrder(SlOrderAddDtos slOrderDots)
        {
            var cusList = (await _slOrderService.Search(t => true)).ToList();
            int max = 0;
            int max2 = 0;
            foreach (var item in cusList)
            {
                if (int.Parse(item.No) > max)
                {
                    max = int.Parse(item.No);
                }
                if(item.Id>max2)
                {
                    max2 = item.Id;
                }
                if(item.Product.Id== slOrderDots.ProductId)
                {
                    slOrderDots.Price = item.Product.Price;//Pirce
                }
            }
            slOrderDots.No = (max + 1).ToString();//No
            slOrderDots.Id = max2 + 1;//Id
            slOrderDots.OrderAmount = slOrderDots.Nums * slOrderDots.Price;//OrderAmount
            slOrderDots.OperatorTime = DateTime.Now;//OperatorTime
            slOrderDots.OrderDate = DateTime.Now;//OrderDate
            slOrderDots.Status = 0;//Status
            //int userid = (await _acUserinfoService.FindAsyncByName(slOrderDots.UserName)).Id;
            slOrderDots.HandleId = UserId;
            slOrderDots.OperatorId = UserId;


            var data = await _slOrderService.Add(_mapper.Map<SlOrder>(slOrderDots));
            InfoResult<SlOrderDots> messageModel = new InfoResult<SlOrderDots>();
            if (data > 0) 
            {
                messageModel.Msg = "添加成功！"; messageModel.Code = 200; messageModel.Success = true; 
            }
            else
            {
                messageModel.Msg = "添加失败！"; messageModel.Code = 400; messageModel.Success = false;
            }
            return Ok(messageModel);
        }


        /// <summary>
        /// 过滤搜索订单信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlCustomerDtos>>> SelectCustomerOrder([FromQuery] CustomerOrderDtosParameters customerOrderDtosParameters)
        {
            var data = (await _slOrderService.Search(t => true)).ToList();
            var data2 = _mapper.Map<List<SlOrderDots>>(data);

            if (!string.IsNullOrWhiteSpace(customerOrderDtosParameters.product)&& customerOrderDtosParameters.product!="所有")
            {
                data2 = data2.Where(t => t.ProductName.Contains(customerOrderDtosParameters.product.ToString())).ToList();
            }
            if (customerOrderDtosParameters.id != 0&&customerOrderDtosParameters.id!=-1)
            {
                data2 = data2.Where(t => t.No.Contains(customerOrderDtosParameters.id.ToString())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(customerOrderDtosParameters.status)&&customerOrderDtosParameters.status!="-100")
            {
                data2 = data2.Where(t => t.Status == int.Parse(customerOrderDtosParameters.status)).ToList();
            }
            return Ok(data2);

        }


        /// <summary>
        /// 查询所有产品和所有的客户
        /// </summary>
        /// <returns>集合对象</returns>
        [HttpGet]
        public async Task<ActionResult<ProductAndCustomerDtos>> SelectAllProductandCustomer()
        {
            var prolist =_mapper.Map<IEnumerable<PrProductDtos>> ((await _prProductService.Search(t => true)).ToList());
            var cuslist = _mapper.Map<IEnumerable<SlCustomerDtos>>((await _slCustomerService.Search(t => true)).ToList());
            ProductAndCustomerDtos productAndCustomerDtos = new ProductAndCustomerDtos() { Product = prolist, Customer = cuslist };
            return Ok(productAndCustomerDtos);
        }






        #endregion


     
    }
}
