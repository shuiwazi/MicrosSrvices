using Newtonsoft.Json;
using RuanMou.MicroService.Core.Cluster;
using RuanMou.MicroService.Core.Registry;
using RuanMou.MicroService.TeamService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RuanMou.MicroService.AggregateService.Services
{
    /// <summary>
    /// 服务调用实现
    /// </summary>
    public class HttpTeamServiceClient : ITeamServiceClient
    {
        public readonly IServiceDiscovery serviceDiscovery;
        public readonly ILoadBalance loadBalance;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string ServiceName = "teamservice"; //服务名称
        private readonly string serviceLink = "/Teams";// 团队链接
        public HttpTeamServiceClient(IServiceDiscovery serviceDiscovery, 
                                    ILoadBalance loadBalance,
                                    IHttpClientFactory httpClientFactory)
        {
            this.serviceDiscovery = serviceDiscovery;
            this.loadBalance = loadBalance;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IList<Team>> GetTeams()
        {
            // 1、获取服务
            IList<ServiceUrl> serviceUrls = await serviceDiscovery.Discovery(ServiceName);

            // 2、负载均衡服务
            ServiceUrl serviceUrl = loadBalance.Select(serviceUrls);

            // 3、建立请求
            HttpClient httpClient = httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(serviceUrl.Url + serviceLink);

            // 3.1json转换成对象
            IList<Team> teams = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                
                teams = JsonConvert.DeserializeObject<List<Team>>(json);
            }
            
            return teams;
        }
    }
}
