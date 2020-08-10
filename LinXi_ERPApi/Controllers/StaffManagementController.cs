using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.StaffManagement.DtoParameters;
using LinXi_Model.DTO.StaffManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 员工管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StaffManagementController : ControllerBase
    {
        #region 依赖注入
        private readonly IAcStaffService _IAcStaffService;
        private readonly IMapper _mapper;
        public StaffManagementController(IAcStaffService IAcStaffService, IMapper mapper)
        {
            this._IAcStaffService = IAcStaffService;
            this._mapper = mapper;
        }
        #endregion


        /// <summary>
        /// 获取所有的员工信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcStaff>>> GetAllStaffInfo()
        {
            var data = (await _IAcStaffService.Search(t => true)).ToList();
            var data2 = _mapper.Map<List<AcStaffDtos>>(data);
            foreach (var item in data2)
            {
                if (item.Sex==1)
                {
                    item.SexName = "男";
                    
                }
                else
                {
                    item.SexName = "女";
                }
                if (item.Status==1)
                {
                    item.StatusStr = "在职";
                }
                else
                {
                    item.StatusStr = "离职";
                }
            }
            return Ok(data2);
        }
        /// <summary>
        /// 获取指定员工的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AcStaff> GetStaffInfo(int id)
        {
            return await _IAcStaffService.FindAsyncById(id); ;
        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddStaff(AcStaff staff)
        {
            return await _IAcStaffService.Add(staff); ;
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<InfoResult<AcStaffDtos>>> UpdateStaff(AcStaffDtos acStaffDtos)
        {
            var data = await _IAcStaffService.Edit(_mapper.Map<AcStaff>(acStaffDtos));
            InfoResult<AcStaffDtos> messageModel = new InfoResult<AcStaffDtos>();
            if (data > 0) { messageModel.Msg = "更新成功"; messageModel.Code = 400; messageModel.Success = true; }
            else
            {
                messageModel.Msg = "更新失败"; messageModel.Code = 201; messageModel.Success = false;
            }
            return Ok(messageModel);
        }
        /// <summary>
        /// 删除客户信息
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<InfoResult<AcStaffDtos>>> DeleteStaffInfo(AcStaffDtos acStaffDtos)
        {
            var data = await _IAcStaffService.Edit(_mapper.Map<AcStaff>(acStaffDtos));
            
            InfoResult<AcStaffDtos> messageModel = new InfoResult<AcStaffDtos>();
            if (data > 0) { messageModel.Msg = "更新成功"; messageModel.Code = 400; messageModel.Success = true; }
            else
            {
                messageModel.Msg = "更新失败"; messageModel.Code = 201; messageModel.Success = false;
            }
            return Ok(messageModel);
        }
        [HttpPut]
        public async Task<int> DeleteStaff(AcStaff staff)
        {
            return await _IAcStaffService.Delete(staff); ;
        }
        /// <summary>
        /// 过滤员工信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcStaffDtos>>> SelectAcStaffInfo([FromQuery] AcStaffDtosParameters staffDtosParameters)
        {
            IEnumerable<AcStaff> list = _mapper.Map<IEnumerable<AcStaff>>(await _IAcStaffService.Search(t => true));
            if (!string.IsNullOrWhiteSpace(staffDtosParameters.name))
            {   
                switch (staffDtosParameters.select)
                {
                    case 1:
                        {
                            var data = list.Where(t => t.Name.Contains(staffDtosParameters.name)).ToList();
                            return Ok(data);
                        }

                    case 2:
                        {
                            var data = list.Where(t => t.DepartmentId==staffDtosParameters.deparmentId).ToList();
                            return Ok(data);
                        }
                   
                }
            }
            return Ok(list);

        }
    }
}
