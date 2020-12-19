using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.RoleMenmusDtos;
using LinXi_Model.DTO.RoleMenmusDtos.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 角色权限管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleMenusController : ControllerBase
    {
        private IServiceProvider _service;
        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;
        private IAcUserinfoService _IAcUserinfoService;
        private IAcRoleService _IAcRloeServie;
        private IAcPermissionService _IAcPermissionService;
        private IAcRolePermissionService _IAcRolePermissionService;
        private ILogger<RoleMenusController> _logger;

        #region 构造方法

        public RoleMenusController(ILogger<RoleMenusController> logger,
                      IAcUserinfoService IAcUserinfoService,
                      IAcPermissionService IAcPermissionService,
                      IAcRolePermissionService IAcRolePermissionService,
                      IAcRoleService IAcRoleService,
                      IHttpContextAccessor httpContext,
                      IServiceProvider service,
                      IMapper IMapper)
        {
            _IMapper = IMapper;
            _service = service;
            _httpContext = httpContext;
            _IAcUserinfoService = IAcUserinfoService;
            _IAcPermissionService = IAcPermissionService;
            _IAcRolePermissionService = IAcRolePermissionService;
            _IAcRloeServie = IAcRoleService;
            _logger = logger;
        }

        #endregion 构造方法

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcUserInfoDtos>>> GetUserInfos()
        {
            var data = (await _IAcUserinfoService.Search(t => true)).ToList();
            var data2 = _IMapper.Map<IEnumerable<AcUserInfoDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcRole>>> GetAcRoles()
        {
            //var data = (await _IAcRloeServie.Search(t => true)).ToList();
            //return Ok(data);

            var productInfo = (await _IAcRloeServie.Search(t => true)).Select(u => new { u.Id, u.Name, }).ToList();
            var ls = new List<AcRole>();
            foreach (var item in productInfo)
            {
                ls.Add(new AcRole() { Id = item.Id, Name = item.Name });
            }
            return ls;
        }

        /// <summary>
        /// 获取所有菜单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PermissionTreeDtos>> GetTreeList(int ParentID = 0)
        {
            List<PermissionTreeDtos> TreeList = new List<PermissionTreeDtos>();
            var list = (await _IAcPermissionService.Search(t => true)).ToList();
            List<AcPermission> ModelList = list.Where(x => x.Pid == ParentID).ToList();
            foreach (var item in ModelList)
            {
                PermissionTreeDtos m = new PermissionTreeDtos();
                m.value = item.Id;
                m.label = item.Name;
                m.children = await GetTreeList(item.Id);
                TreeList.Add(m);
            }
            return TreeList;

            //var data = (await _IAcPermissionService.Search(t => true)).ToList();
            //return Ok(data);
        }

        /// <summary>
        /// 角色权限修改
        /// </summary>
        /// <param name="role"></param>
        /// <param name="permissios"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InfoResult<AcRolePermission>>> EdRolePermission(int role, string permissios)
        {
            int[] permissio = JsonConvert.DeserializeObject<int[]>(permissios);

            var cusList = await _IAcRolePermissionService.Search(t => true);
            int max = 0;
            foreach (var item in cusList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            int Id = max + 1;

            int d = 0;
            int result = 0;

            List<int> newArr = new List<int>();

            foreach (var item in permissio)
            {
                if (newArr.IndexOf(item) == -1)
                {
                    newArr.Add(item);
                }
            }

            var data1 = (await _IAcRolePermissionService.Search(t => t.RoleId == role)).ToList();
            foreach (var item in data1)
            {
                d += await _IAcRolePermissionService.Delete(item);
            }

            foreach (var item in newArr)
            {
                AcRolePermission acRolePermission = new AcRolePermission();
                acRolePermission.Id = Id;
                acRolePermission.RoleId = role;
                acRolePermission.PermissionId = item;
                result = await _IAcRolePermissionService.Add(acRolePermission);
                Id += 1;
            }
            InfoResult<AcRolePermission> messageModel = new InfoResult<AcRolePermission>();

            if (result > 0)
            {
                messageModel.Msg = "授权成功！"; messageModel.Code = 400; messageModel.Success = true;
            }
            else
            {
                messageModel.Msg = "授权失败！"; messageModel.Code = 201; messageModel.Success = false;
            }
            return Ok(messageModel);
        }

        /// <summary>
        ///用户角色修改
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<AcUserinfo>>> EdUserInfo(String userInfo)
        {
            AcUserInfoDtos permissio = JsonConvert.DeserializeObject<AcUserInfoDtos>(userInfo);
            var resert = _IMapper.Map<AcUserinfo>(permissio);
            var data = await _IAcUserinfoService.Edit(resert);
            InfoResult<AcUserinfo> messageModel = new InfoResult<AcUserinfo>();
            if (data > 0)
            {
                messageModel.Msg = "授权成功！"; messageModel.Code = 400; messageModel.Success = true;
            }
            else
            {
                messageModel.Msg = "授权失败！"; messageModel.Code = 201; messageModel.Success = false;
            }
            return Ok(messageModel);
        }
    }
}