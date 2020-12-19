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
        private readonly IAcDepartmentService _IAcDepartmentService;

        public StaffManagementController(IAcStaffService IAcStaffService, IMapper mapper, IAcDepartmentService acDepartmentService)
        {
            this._IAcStaffService = IAcStaffService;
            this._mapper = mapper;
            _IAcDepartmentService = acDepartmentService;
        }

        #endregion 依赖注入

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
                if (item.Sex == 1)
                {
                    item.SexName = "男";
                }
                else
                {
                    item.SexName = "女";
                }
                if (item.Status == 1)
                {
                    item.StatusStr = "在职";
                }
                else if (item.Status == 0)
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
        /// <param name="acStaffDtos"></param>
        [HttpPost]
        public async Task<ActionResult<InfoResult<AcStaffDtos>>> AddStaff(AcStaffDtos acStaffDtos)
        {
            var NewDepartment = (await _IAcDepartmentService.Search(u => u.Name == acStaffDtos.DeparmentName)).FirstOrDefault();
            acStaffDtos.DepartmentId = NewDepartment.Id;
            var staffList = await _IAcStaffService.Search(t => true);
            int max = 0;
            foreach (var item in staffList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            acStaffDtos.Id = max + 1;
            InfoResult<AcStaffDtos> messageModel = new InfoResult<AcStaffDtos>();
            var data = await _IAcStaffService.Add(_mapper.Map<AcStaff>(acStaffDtos));
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
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> DeleteStaff(AcStaffDtos acStaffDtos)
        {
            var NewStaff = (await _IAcStaffService.Search(u => u.Id == acStaffDtos.Id)).FirstOrDefault();
            InfoResult<AcStaffDtos> messageModel = new InfoResult<AcStaffDtos>();
            if (NewStaff != null)
            {
                if (NewStaff.Status == 0)
                {
                    messageModel.Msg = "该员工已处于离职状态";
                    return Ok(messageModel);
                }
                else
                {
                    //将员工状态修改为离职
                    NewStaff.Status = 0;
                    var data = (await _IAcStaffService.Search(t => true)).ToList();
                    var data2 = _mapper.Map<List<AcStaffDtos>>(data);
                    foreach (var item in data2)
                    {
                        if (item.Status == 0)
                        {
                            item.StatusStr = "离职";
                        }
                    }
                    return await _IAcStaffService.Edit(NewStaff) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
                }
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> UpdateStaff(AcStaffDtos acStaffDtos)
        {
            var NewStaff = (await _IAcStaffService.Search(u => u.Id == acStaffDtos.Id)).FirstOrDefault();
            InfoResult<AcStaffDtos> messageModel = new InfoResult<AcStaffDtos>();
            if (NewStaff != null)
            {
                NewStaff.Id = acStaffDtos.Id;
                NewStaff.Name = acStaffDtos.Name;
                NewStaff.Sex = (sbyte)acStaffDtos.Sex;
                NewStaff.No = acStaffDtos.No;
                NewStaff.Address = acStaffDtos.Address;
                NewStaff.Tel = acStaffDtos.Tel;
                NewStaff.DepartmentId = acStaffDtos.DepartmentId;
                NewStaff.Status = (sbyte)acStaffDtos.Status;
                return await _IAcStaffService.Edit(NewStaff) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
            }
            return Ok(messageModel);
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
                            var data2 = _mapper.Map<List<AcStaffDtos>>(data);
                            foreach (var item in data2)
                            {
                                if (item.Sex == 1)
                                {
                                    item.SexName = "男";
                                }
                                else
                                {
                                    item.SexName = "女";
                                }
                                if (item.Status == 1)
                                {
                                    item.StatusStr = "在职";
                                }
                                else if (item.Status == 0)
                                {
                                    item.StatusStr = "离职";
                                }
                            }
                            return Ok(data2);
                        }
                }
            }
            else
            {
                var data = (await _IAcStaffService.Search(t => true)).ToList();
                var data2 = _mapper.Map<List<AcStaffDtos>>(data);
                foreach (var item in data2)
                {
                    if (item.Sex == 1)
                    {
                        item.SexName = "男";
                    }
                    else
                    {
                        item.SexName = "女";
                    }
                    if (item.Status == 1)
                    {
                        item.StatusStr = "在职";
                    }
                    else if (item.Status == 0)
                    {
                        item.StatusStr = "离职";
                    }
                }
                return Ok(data2);
            }
            return Ok(list);
        }
    }
}