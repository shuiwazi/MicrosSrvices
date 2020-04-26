using RuanMou.MicroService.TeamService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuanMou.MicroService.TeamService.Repositories
{
    /// <summary>
    /// 团队成员仓储接口
    /// </summary>
   public interface IMemberRepository
   {
        IEnumerable<Member> GetMembers();
        Member GetMemberById(int id);
        IEnumerable<Member> GetMembers(int teamId);
        void Create(Member member);
        void Update(Member member);
        void Delete(Member member);
        bool MemberExists(int id);
    }
}
