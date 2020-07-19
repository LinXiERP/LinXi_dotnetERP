using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LinXi_Model;
using LinXi_Model.DTO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinXi_ERPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IServiceProvider _service;
        private readonly IMapper _IMapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(ILogger<LoginController> logger,
            IServiceProvider service,
            IMapper IMapper,
             IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _service = service;
            _IMapper = IMapper;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 登录判断
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<InfoResult<LoginDTO>>> LoginCheck(LoginDTO loginDTO)
        {
            AcUserinfo userinfo = _IMapper.Map<AcUserinfo>(loginDTO);
            var client = _httpClientFactory.CreateClient();

            var dic = new Dictionary<string, object>
            {
               { "grant_type", "password" },
               { "client_id","client2" },
               { "client_secret","secret" },
               {"username",userinfo.Account},
               { "password",userinfo.Pwd}
            };
            var dic_str = dic.Select(m => m.Key + "=" + m.Value).DefaultIfEmpty().Aggregate((m, n) => m + "&" + n);

            #region 请求token

            HttpContent httpcontent = new StringContent(dic_str);
            httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var oauth_rep = await client.PostAsync("http://localhost:56568/connect/token", httpcontent);
            var oauth_str = await oauth_rep.Content.ReadAsStringAsync();
            var oauth_job = JsonConvert.DeserializeObject<JObject>(oauth_str);

            #endregion 请求token

            if (oauth_job["access_token"] == null)
            {
                return new InfoResult<LoginDTO>()
                {
                    Msg = "账号密码不匹配",
                    Entity = new LoginDTO(),
                    Success = false
                };
            }
            else
            {
                return new InfoResult<LoginDTO>()
                {
                    Msg = oauth_job["access_token"].ToString(),
                    Entity = new LoginDTO { Name = loginDTO.Name }
                };
            }
        }
    }
}