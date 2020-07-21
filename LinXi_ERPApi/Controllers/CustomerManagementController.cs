using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.CustomerManageManage.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IMapper _mapper;

        public CustomerManagementController(ISlCustomerService slCustomerService, IMapper mapper)
        {
            this._slCustomerService = slCustomerService;
            this._mapper = mapper;
        }

        #endregion


        /// <summary>
        /// 获取所有的客户信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlCustomerDtos>>> GetAllCustomerInfo()
        {
            var data= _mapper.Map<IEnumerable<SlCustomerDtos>>(await _slCustomerService.Search(t => true));
            return Ok(data);
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<SlCustomerDtos>>> DeleteCustomerInfo(int id)
        {
            SlCustomerDtos slCustomerDtos = new SlCustomerDtos();
            slCustomerDtos.Id = id;

            InfoResult<SlCustomerDtos> messageModel = new InfoResult<SlCustomerDtos>();
            int data = 0;
            try { 
               data =await _slCustomerService.Delete(_mapper.Map<SlCustomer>(slCustomerDtos));
            }
            catch
            {
                messageModel.Success = false;
                messageModel.Code = 201;
                messageModel.Msg = "删除失败!";
                return Ok(messageModel);
            }
            if (data>0)
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
    }
}
