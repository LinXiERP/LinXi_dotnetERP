using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LinXi_IService;
using LinXi_Model;
using LinXi_Model.DTO.AcSalaryManagement.DtoParameters;
using LinXi_Model.DTO.AcSalaryManagement.Dtos;
using LinXi_Model.DTO.StaffManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinXi_ERPApi.Controllers
{
    /// <summary>
    /// 薪资管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AcSalaryManagementController : ControllerBase
    {
        #region 依赖注入

        private readonly IAcSalaryService _IAcSalaryService;
        private readonly IAcStaffService _IAcStaffService;
        private readonly IMapper _mapper;

        public AcSalaryManagementController(IAcSalaryService IAcSalaryService, IAcStaffService IAcStaffService, IMapper mapper)
        {
            this._IAcStaffService = IAcStaffService;
            this._IAcSalaryService = IAcSalaryService;
            this._mapper = mapper;
        }

        #endregion 依赖注入

        /// <summary>
        /// 获取所有的薪资信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcSalary>>> SelectAllSalary()
        {
            var data = (await _IAcSalaryService.Search(t => true)).ToList();
            var data2 = _mapper.Map<List<AcSalaryDtos>>(data);
            foreach (var item in data2)
            {
                if (item.sex == 1)
                {
                    item.SexName = "男";
                }
                else
                {
                    item.SexName = "女";
                }
                item.Createdate = item.Createdate.Substring(0, 10);
                item.Grant = item.Createdate.Substring(0, 10);
                item.Sum = item.Base + item.Lunch + item.Live + item.Hardwork + item.Extra + item.Forfeit + item.Tax;
            }
            return Ok(data2);
        }

        /// <summary>
        /// 添加薪资
        /// </summary>
        /// <param name="acSalaryDtos"></param>
        [HttpPost]
        public async Task<ActionResult<InfoResult<AcSalaryDtos>>> AddSalary(AcSalaryDtos acSalaryDtos)
        {
            var NewSalary = (await _IAcStaffService.Search(u => u.Id == acSalaryDtos.StaffId)).FirstOrDefault();
            var salaryList = await _IAcSalaryService.Search(t => true);
            int max = 0;
            foreach (var item in salaryList)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            acSalaryDtos.Id = max + 1;
            acSalaryDtos.Address = NewSalary.Address;
            acSalaryDtos.DepartmentName = NewSalary.Department.Name;
            acSalaryDtos.Name = NewSalary.Name;
            acSalaryDtos.sex = NewSalary.Sex;
            acSalaryDtos.StaffId = NewSalary.Id;
            acSalaryDtos.tel = NewSalary.Tel;
            acSalaryDtos.Createdate = DateTime.Now.ToString();
            acSalaryDtos.Createdate = acSalaryDtos.Createdate.Substring(0, 10);
            acSalaryDtos.Sum = acSalaryDtos.Base + acSalaryDtos.Lunch + acSalaryDtos.Live + acSalaryDtos.Hardwork + acSalaryDtos.Extra + acSalaryDtos.Forfeit + acSalaryDtos.Tax;
            InfoResult<AcSalaryDtos> messageModel = new InfoResult<AcSalaryDtos>();
            var data = await _IAcSalaryService.Add(_mapper.Map<AcSalary>(acSalaryDtos));
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
        /// 修改薪资信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<InfoResult<string>>> UpdateSalary(AcSalaryDtos acSalaryDtos)
        {
            var NewSalary = (await _IAcSalaryService.Search(u => u.Id == acSalaryDtos.Id)).FirstOrDefault();
            InfoResult<AcSalaryDtos> messa1geModel = new InfoResult<AcSalaryDtos>();
            if (NewSalary != null)
            {
                NewSalary.Createdate = acSalaryDtos.Createdate;
                NewSalary.Base = acSalaryDtos.Base;
                NewSalary.Lunch = acSalaryDtos.Lunch;
                NewSalary.Live = acSalaryDtos.Live;
                NewSalary.Hardwork = acSalaryDtos.Hardwork;
                NewSalary.Extra = acSalaryDtos.Extra;
                NewSalary.Forfeit = acSalaryDtos.Forfeit;
                NewSalary.Tax = acSalaryDtos.Tax;
                NewSalary.Sum = acSalaryDtos.Base + acSalaryDtos.Lunch + acSalaryDtos.Live + acSalaryDtos.Hardwork + acSalaryDtos.Extra + acSalaryDtos.Forfeit + acSalaryDtos.Tax;
                return await _IAcSalaryService.Edit(NewSalary) > 0 ? new InfoResult<string>("修改成功！") : new InfoResult<string>("修改失败！");
            }
            return Ok(messa1geModel);
        }

        /// <summary>
        /// 过滤薪资信息
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcSalaryDtos>>> SelectAcSalaryInfo([FromQuery] AcSalaryDtoParameters acSalaryDtoParameters)
        {
            IEnumerable<AcSalary> list = _mapper.Map<IEnumerable<AcSalary>>(await _IAcSalaryService.Search(t => true));
            if (!string.IsNullOrWhiteSpace(acSalaryDtoParameters.name))
            {
                switch (acSalaryDtoParameters.select)
                {
                    case 1:
                        {
                            var data = list.Where(t => t.Staff.Name.Contains(acSalaryDtoParameters.name)).ToList();
                            var data2 = _mapper.Map<List<AcSalaryDtos>>(data);
                            foreach (var item in data2)
                            {
                                if (item.sex == 1)
                                {
                                    item.SexName = "男";
                                }
                                else
                                {
                                    item.SexName = "女";
                                }
                                item.Createdate = DateTime.Now.ToString();
                                item.Createdate = item.Createdate.Substring(0, 10);
                                item.Sum = item.Base + item.Lunch + item.Live + item.Hardwork + item.Extra + item.Forfeit + item.Tax;
                            }
                            return Ok(data2);
                        }
                }
            }
            else
            {
                var data = (await _IAcSalaryService.Search(t => true)).ToList();
                var data2 = _mapper.Map<List<AcSalaryDtos>>(data);
                foreach (var item in data2)
                {
                    if (item.sex == 1)
                    {
                        item.SexName = "男";
                    }
                    else
                    {
                        item.SexName = "女";
                    }
                    item.Createdate = DateTime.Now.ToString();
                    item.Createdate = item.Createdate.Substring(0, 10);
                    item.Sum = item.Base + item.Lunch + item.Live + item.Hardwork + item.Extra + item.Forfeit + item.Tax;
                }
                return Ok(data2);
            }
            return Ok(list);
        }
    }
}