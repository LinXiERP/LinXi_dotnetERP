using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.AcDeparmentManage.Dtos;
using LinXi_Model.DTO.AcDeparmentManage.Parameters;

//using LinXi_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 部门管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AcDepartmentController : ControllerBase
    {
        #region 字段

        private ILogger<AcDepartmentController> _logger;

        private IAcDepartmentService _IAcDepartmentService;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;

        private readonly static object obj = new object();

        #endregion 字段

        #region 构造函数注入

        public AcDepartmentController(
            ILogger<AcDepartmentController> logger,
            IAcDepartmentService IAcDepartmentService,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _IAcDepartmentService = IAcDepartmentService;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;
        }

        #endregion 构造函数注入

        /// <summary>
        /// 获取所有的部门信息
        ///  </summary>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDepartment>>> GetAllDeparmentInfo()
        {
            var data = (await _IAcDepartmentService.Search(t => true)).ToList();
            var data2 = _IMapper.Map<List<AcDeparmentDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> Updatedepartment(AcDeparmentDtos acDeparmentDtos)
        {
            var NewDepartment = (await _IAcDepartmentService.Search(u => u.Id == acDeparmentDtos.Id)).FirstOrDefault();
            InfoResult<AcDeparmentDtos> messageModel = new InfoResult<AcDeparmentDtos>();
            if (NewDepartment != null)
            {
                NewDepartment.Name = acDeparmentDtos.Name;
                NewDepartment.Remark = acDeparmentDtos.remark;
                return await _IAcDepartmentService.Edit(NewDepartment) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="acDeparmentDtos"></param>
        [HttpPost]
        public async Task<ActionResult<InfoResult<AcDeparmentDtos>>> Adddepartment(AcDeparmentDtos acDeparmentDtos)
        {
            var departmentList = await _IAcDepartmentService.Search(t => true);
            int max = 0;
            foreach (var item in departmentList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            acDeparmentDtos.Id = max + 1;
            InfoResult<AcDeparmentDtos> messageModel = new InfoResult<AcDeparmentDtos>();
            var data = await _IAcDepartmentService.Add(_IMapper.Map<AcDepartment>(acDeparmentDtos));
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
        /// 过滤部门信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDeparmentDtos>>> SelectAcDepartmentInfo([FromQuery] AcDepartmentDtoParameters acDepartmentDtoParameters)
        {
            IEnumerable<AcDepartment> list = _IMapper.Map<IEnumerable<AcDepartment>>(await _IAcDepartmentService.Search(t => true));
            if (!string.IsNullOrWhiteSpace(acDepartmentDtoParameters.name))
            {
                switch (acDepartmentDtoParameters.select)
                {
                    case 1:
                        {
                            var data2 = _IMapper.Map<List<AcDeparmentDtos>>(list);
                            var data = data2.Where(t => t.Name.Contains(acDepartmentDtoParameters.name)).ToList();
                            return Ok(data);
                        }
                }
            }
            else
            {
                var data = (await _IAcDepartmentService.Search(t => true)).ToList();
                var data2 = _IMapper.Map<List<AcDeparmentDtos>>(data);
                return Ok(data2);
            }
            return Ok(list);
        }
    }
}