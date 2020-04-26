using RuanMou.MicroService.TeamService.Models;
using RuanMou.MicroService.TeamService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuanMou.MicroService.TeamService.Services
{
    /// <summary>
    /// 团队服务实现
    /// </summary>
    public class TeamServiceImpl : ITeamService
    {
        public readonly ITeamRepository teamRepository;

        public TeamServiceImpl(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public void Create(Team team)
        {
            teamRepository.Create(team);
        }

        public void Delete(Team team)
        {
            teamRepository.Delete(team);
        }

        public Team GetTeamById(int id)
        {
            return teamRepository.GetTeamById(id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return teamRepository.GetTeams();
        }

        public void Update(Team team)
        {
            teamRepository.Update(team);
        }

        public bool TeamExists(int id)
        {
            return teamRepository.TeamExists(id);
        }
    }
}
