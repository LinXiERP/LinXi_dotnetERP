using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.AcNoticeManage.Dtos;
using LinXi_Model.DTO.AcNoticeManage.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 公告管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AcNoticeController : ControllerBase
    {
        #region 依赖注入

        private readonly IAcNoticeService _IAcNoticeService;
        private readonly IMapper _mapper;

        public AcNoticeController(IAcNoticeService IAcNoticeService, IMapper mapper)
        {
            this._IAcNoticeService = IAcNoticeService;
            this._mapper = mapper;
        }

        #endregion 依赖注入

        /// <summary>
        /// 获取所有的公告信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcNotice>>> GetAllNoticeInfo()
        {
            var data = (await _IAcNoticeService.Search(t => true)).ToList();
            var data2 = _mapper.Map<List<AcNoticeDtos>>(data);
            foreach (var item in data2)
            {
                item.Createdate = item.Createdate.Substring(0, 10);
            }

            return Ok(data2);
        }

        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="acNoticeDtos"></param>
        [HttpPost]
        public async Task<ActionResult<InfoResult<AcNoticeDtos>>> Addnotice(AcNoticeDtos acNoticeDtos)
        {
            var noticeList = await _IAcNoticeService.Search(t => true);
            int max = 0;
            foreach (var item in noticeList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            acNoticeDtos.Id = max + 1;
            acNoticeDtos.Createdate = DateTime.Now.ToString();
            InfoResult<AcNoticeDtos> messageModel = new InfoResult<AcNoticeDtos>();
            var data = await _IAcNoticeService.Add(_mapper.Map<AcNotice>(acNoticeDtos));
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
        /// 修改公告信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> Updatenotice(AcNoticeDtos acNoticeDtos)
        {
            var NewNotice = (await _IAcNoticeService.Search(u => u.Id == acNoticeDtos.Id)).FirstOrDefault();
            InfoResult<AcNoticeDtos> messageModel = new InfoResult<AcNoticeDtos>();
            if (NewNotice != null)
            {
                NewNotice.Title = acNoticeDtos.Title;
                NewNotice.Detail = acNoticeDtos.Detail;
                return await _IAcNoticeService.Edit(NewNotice) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
            }
            return Ok(messageModel);
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<InfoResult<AcNoticeDtos>>> Deletenotice(AcNoticeDtos acNoticeDtos)
        {
            var data = await _IAcNoticeService.Delete(_mapper.Map<AcNotice>(acNoticeDtos));
            InfoResult<AcNoticeDtos> messageModel = new InfoResult<AcNoticeDtos>();
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
        /// 过滤公告信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcNoticeDtos>>> SelectAcNoticeInfo([FromQuery] AcNoticeParameters acNoticeParameters)
        {
            IEnumerable<AcNotice> list = _mapper.Map<IEnumerable<AcNotice>>(await _IAcNoticeService.Search(t => true));
            if (!string.IsNullOrWhiteSpace(acNoticeParameters.name))
            {
                switch (acNoticeParameters.select)
                {
                    case 1:
                        {
                            var data2 = _mapper.Map<List<AcNoticeDtos>>(list);
                            var data = data2.Where(t => t.Title.Contains(acNoticeParameters.name)).ToList();
                            return Ok(data);
                        }
                }
            }
            else
            {
                var data = (await _IAcNoticeService.Search(t => true)).ToList();
                var data2 = _mapper.Map<List<AcNoticeDtos>>(data);
                return Ok(data2);
            }
            return Ok(list);
        }
    }
}