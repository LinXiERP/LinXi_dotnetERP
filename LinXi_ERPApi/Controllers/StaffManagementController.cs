using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
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
        public async Task<ActionResult<IEnumerable<AcStaffDtos>>> GetAllStaffInfo()
        {
            var data = _mapper.Map<IEnumerable<AcStaffDtos>>(await _IAcStaffService.Search(t => true));
            return Ok(data);
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
        [HttpGet]
        public async Task<int> AddStaff(AcStaff staff)
        {
            return await _IAcStaffService.Add(staff); ;
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> EditStaff(AcStaff staff)
        {
            return await _IAcStaffService.Edit(staff); ;
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> DeleteStaff(AcStaff staff)
        {
            return await _IAcStaffService.Delete(staff); ;
        }
    }
}
