using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuanMou.MicroService.AggregateService.Services;
using RuanMou.MicroService.TeamService.Models;

namespace RuanMou.MicroService.AggregateService.Controllers
{
    [Route("api/Teams")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private readonly ITeamServiceClient teamServiceClient;

        public AggregateController(ITeamServiceClient teamServiceClient)
        {
            this.teamServiceClient = teamServiceClient;
        }

        // GET: api/Aggregate
        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {
            /*// 1、查询团队
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/Teams");
            
            string json = await response.Content.ReadAsStringAsync();
            IList<Team> teams = JsonConvert.DeserializeObject<List<Team>>(json);*/
            /*// 2、查询团队成员
            foreach (var team in teams)
            {
                HttpResponseMessage response1 = await httpClient.GetAsync($"https://localhost:5002/Members?teamId={team.Id}");
                string json1 = await response1.Content.ReadAsStringAsync();

                List<Member> members = JsonConvert.DeserializeObject<List<Member>>(json1);

                team.Members = members;
            }*/
            IList<Team> teams = await teamServiceClient.GetTeams();
            return Ok(teams);
        }

        // GET: api/Aggregate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Aggregate
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Aggregate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
