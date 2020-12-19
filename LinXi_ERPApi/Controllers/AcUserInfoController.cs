using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.AcUserInfo.DtoParameters;
using LinXi_Model.DTO.AcUserInfo.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 账户管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AcUserInfoController : ControllerBase
    {
        #region 依赖注入

        private readonly IAcUserinfoService _IAcUserinfoService;
        private readonly IAcRoleService _IAcRoleServicee;
        private readonly IAcStaffService _IAcStaffServicee;
        private readonly IMapper _mapper;

        public AcUserInfoController(IAcUserinfoService IAcUserinfoService, IAcStaffService IAcStaffService, IAcRoleService IAcRoleService, IMapper mapper)
        {
            this._IAcStaffServicee = IAcStaffService;
            this._IAcRoleServicee = IAcRoleService;
            this._IAcUserinfoService = IAcUserinfoService;
            this._mapper = mapper;
        }

        #endregion 依赖注入

        /// <summary>
        /// 获取所有的账户信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcUserinfo>>> GetAlluserInfo()
        {
            var data = (await _IAcUserinfoService.Search(t => true)).ToList();
            var data2 = _mapper.Map<List<AcUserInfoManageDtos>>(data);
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
                    item.Statustr = "正常";
                }
                else if (item.Status == 0)
                {
                    item.Statustr = "冻结";
                }
            }
            return Ok(data2);
        }

        /// <summary>
        /// 获取所有的账户信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcRole>>> GetAllRoleInfo()
        {
            var RoleInfo = (await _IAcRoleServicee.Search(t => true)).Select(u => new { u.Id, u.Name, u.Remark }).ToList();
            return Ok(RoleInfo);
        }

        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// <param name="acUserinfo"></param>
        [HttpPost]
        public async Task<ActionResult<InfoResult<AcUserinfo>>> Adduser(AcUserInfoManageDtos acUserinfo)
        {
            var userList = await _IAcUserinfoService.Search(t => true);
            int max = 0;
            foreach (var item in userList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            acUserinfo.Id = max + 1;
            acUserinfo.Status = 1;
            InfoResult<AcUserinfo> messageModel = new InfoResult<AcUserinfo>();
            var data = await _IAcUserinfoService.Add(_mapper.Map<AcUserinfo>(acUserinfo));
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
        /// 注销账户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> DeleteAccount(AcUserInfoManageDtos acUserInfoDtos)
        {
            var NewAccount = (await _IAcUserinfoService.Search(u => u.Id == acUserInfoDtos.Id)).FirstOrDefault();
            InfoResult<AcUserInfoManageDtos> messageModel = new InfoResult<AcUserInfoManageDtos>();
            if (NewAccount != null)
            {
                if (NewAccount.Status == 0)
                {
                    messageModel.Msg = "该账户已处于注销状态";
                    return Ok(messageModel);
                }
                else
                {
                    //将账户状态修改为冻结
                    NewAccount.Status = 0;
                    var data = (await _IAcUserinfoService.Search(t => true)).ToList();
                    var data2 = _mapper.Map<List<AcUserInfoManageDtos>>(data);
                    foreach (var item in data2)
                    {
                        if (item.Status == 0)
                        {
                            item.Statustr = "冻结";
                        }
                    }
                    return await _IAcUserinfoService.Edit(NewAccount) > 0 ? new InfoResult<string>("注销成功！") : new InfoResult<string>("注销失败！");
                }
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 过滤账户信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcUserInfoManageDtos>>> SelectUserInfo([FromQuery] AcUserInfoParameters acUserInfoParameters)
        {
            IEnumerable<AcUserinfo> list = _mapper.Map<IEnumerable<AcUserinfo>>(await _IAcUserinfoService.Search(t => true));
            if (!string.IsNullOrWhiteSpace(acUserInfoParameters.name))
            {
                switch (acUserInfoParameters.select)
                {
                    case 1:
                        {
                            var data2 = _mapper.Map<List<AcUserInfoManageDtos>>(list);
                            var data = data2.Where(t => t.Name.Contains(acUserInfoParameters.name)).ToList();
                            foreach (var item in data)
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
                                    item.Statustr = "正常";
                                }
                                else if (item.Status == 0)
                                {
                                    item.Statustr = "冻结";
                                }
                            }
                            return Ok(data);
                        }
                }
            }
            else
            {
                var data = (await _IAcUserinfoService.Search(t => true)).ToList();
                var data2 = _mapper.Map<List<AcUserInfoManageDtos>>(data);
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
                        item.Statustr = "正常";
                    }
                    else if (item.Status == 0)
                    {
                        item.Statustr = "冻结";
                    }
                }
                return Ok(data2);
            }
            return Ok(list);
        }

        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> UpdateUser(AcUserInfoManageDtos acUserInfoDtos)
        {
            var NewUser = (await _IAcUserinfoService.Search(u => u.Id == acUserInfoDtos.Id)).FirstOrDefault();
            InfoResult<AcUserInfoManageDtos> messa1geModel = new InfoResult<AcUserInfoManageDtos>();
            if (NewUser != null)
            {
                NewUser.Account = acUserInfoDtos.Account;
                NewUser.Id = acUserInfoDtos.Id;
                NewUser.Pwd = acUserInfoDtos.Pwd;
                NewUser.RoleId = acUserInfoDtos.RoleId;
                NewUser.StaffId = acUserInfoDtos.StaffId;
                NewUser.Status = acUserInfoDtos.Status;
                return await _IAcUserinfoService.Edit(NewUser) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
            }
            return Ok(messa1geModel);
        }
    }
}