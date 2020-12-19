using Consul;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace LinXi_ERPApi
{
    public static class ConsulSetup
    {
        public static void UseConsulRegist(this IConfiguration configuration, IServerAddressesFeature feature)
        {
            //string ServerAddress = feature.Addresses.FirstOrDefault();
            //configuration["IP"] = ServerAddress.Substring(7, 9);
            //configuration["Port"] = ServerAddress.Substring(17, 5);

            ConsulClient client = new ConsulClient(c =>
            {
                //找到 Consul地址，默认地址
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "东方曜";
            });

            string ip = configuration["ServerInfo:IP"];
            int weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);
            int port = int.Parse(configuration["ServerInfo:Port"]);
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ///微服务唯一标识，唯一的
                ID = "service_" + port,
                Name = "ApiGateWayService",//同一份代码的集群
                Address = ip,
                Port = port,
                ///标签参数，可以在注册的时候根据拿到tags标签来当权重，可以是属于地址参数上的tag
                ///注册服务时指定权重，分配时获取权重并以此为依据分配实例
                Tags = new string[] { weight.ToString() },

                #region 配置心跳检查

                Check = new AgentServiceCheck()
                {
                    //心跳时间
                    Interval = TimeSpan.FromSeconds(12),
                    //心跳地址
                    HTTP = $"http://{ip}:{port}/api/Health/Index",
                    //超时时间
                    Timeout = TimeSpan.FromSeconds(5),
                    //取消服务注册时间
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(20),
                }

                #endregion 配置心跳检查
            });
        }
    }
}