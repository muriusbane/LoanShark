using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using LoanShark.Models;
using LoanShark.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LoanShark.Data
{
    public class MemberRepository
    {
        private readonly AppDbContext _db;
        public MemberRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<MemberDisplayViewModel> GetMembers()
        {
            List<Member> members = new List<Member>();
            members = _db.Members.AsNoTracking().ToList();

            if (members != null)
            {
                List<MemberDisplayViewModel> membersDisplay = new List<MemberDisplayViewModel>();
                foreach (var obj in members)
                {
                    var memberDisplay = new MemberDisplayViewModel()
                    {
                        MemberId = obj.MemberId,
                        FirstName = obj.FirstName,
                        MiddleName = obj.MiddleName,
                        LastName = obj.LastName
                    };
                    membersDisplay.Add(memberDisplay);
                }
                return membersDisplay;
            }
            return null;
        }
    }
}
