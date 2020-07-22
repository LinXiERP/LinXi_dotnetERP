using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinXi_ERPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommodityInventoryController : ControllerBase
    {
        private ILogger<CommodityInventoryController> _logger;

        private IPuCommodityServicce _IPuCommodityServicce;
        private IServiceProvider _service;

        private IMapper _IMapper;
        private IHttpContextAccessor _httpContext;


        #region 构造函数注入
        public CommodityInventoryController(ILogger<CommodityInventoryController> logger,
            IPuCommodityServicce IPuCommodityServicce,
            IServiceProvider service,
            IMapper IMapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _logger = logger;
            _IPuCommodityServicce = IPuCommodityServicce;
            _service = service;
            _IMapper = IMapper;
            _httpContext = httpContextAccessor;

        }
        #endregion

        /// <summary>
        /// 全部商品信息
        /// </summary>
        /// <returns></returns>
       
        [HttpGet]
   
        public async Task< ActionResult<IEnumerable<PuCommodity>>> GetPrProductInfo()
        {
            var data= await  _IPuCommodityServicce.Search(t=>true);
            return Ok(data);
                
        }


   
        /// <summary>
        /// 筛选商品信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task< ActionResult<IEnumerable<PuCommodity>>> ScreenPrProductInfo(string name, string category)
        {
            var data = await _IPuCommodityServicce.Search(t => t.Name == name && t.Supplier.Name == category);
            return Ok(data);

        }
      
    }
}
