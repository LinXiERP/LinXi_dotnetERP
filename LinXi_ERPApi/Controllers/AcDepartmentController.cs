using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.AcDeparmentManage.Dtos;

//using LinXi_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
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
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcDepartment>>> GetAllDeparmentInfo()
        {
            var data = (await _IAcDepartmentService.Search(t => true)).ToList();
            var data2 = _IMapper.Map<List<AcDeparmentDtos>>(data);
            return Ok(data2);
        }

        /// <summary>
        /// 修改xx表的资料
        /// </summary>
        /// <param name="de">xx类</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/[controller]/[action]")]
        public async Task<int> EditAC(AcDepartment de)
        {
            return await _IAcDepartmentService.Edit(de); ;
        }
    }
}