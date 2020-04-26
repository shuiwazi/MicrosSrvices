using RuanMou.MicroService.TeamService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuanMou.MicroService.MemberService.Services
{
    /// <summary>
    /// 团队服务接口
    /// </summary>
    public interface IMemberService
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberById(int id);
        void Create(Member member);
        void Update(Member member);
        void Delete(Member member);
        bool MemberExists(int id);
        IEnumerable<Member> GetMembers(int teamId);
    }
}
