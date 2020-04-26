using RuanMou.MicroService.TeamService.Models;
using RuanMou.MicroService.TeamService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuanMou.MicroService.MemberService.Services
{
    /// <summary>
    /// 团队服务实现
    /// </summary>
    public class MemberServiceImpl : IMemberService
    {
        public readonly IMemberRepository memberRepository;

        public MemberServiceImpl(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public void Create(Member member)
        {
            memberRepository.Create(member);
        }

        public void Delete(Member member)
        {
            memberRepository.Delete(member);
        }

        public Member GetMemberById(int id)
        {
            return memberRepository.GetMemberById(id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return memberRepository.GetMembers();
        }
        
        public void Update(Member member)
        {
            memberRepository.Update(member);
        }

        public bool MemberExists(int id)
        {
            return memberRepository.MemberExists(id);
        }

        public IEnumerable<Member> GetMembers(int teamId)
        {
            return memberRepository.GetMembers(teamId);
        }
    }
}
