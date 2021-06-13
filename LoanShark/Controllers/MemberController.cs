using LoanShark.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanShark.ViewModel;

namespace LoanShark.Controllers
{
    public class MemberController : Controller
    {

        private readonly AppDbContext _db;
        public MemberController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var repo = new MemberRepository(_db);
            var memberList = repo.GetMembers();
            return View(memberList);
        }

        public IActionResult Create()
        {
            var repo = new MemberRepository(_db);
            var member = repo.CreateMember();
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new MemberRepository(_db);
                bool saved = repo.SaveMember(model);
                if (saved)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);

        }

        public IActionResult Edit(Guid id)
        {
            var member = _db.Members.SingleOrDefault(m => m.MemberId == id);
            
            if (member == null)
            {
                return NotFound();
            }
            var memberEdit = new MemberEditViewModel
            {
                FirstName = member.FirstName,
                MiddleName = member.MiddleName,
                LastName = member.LastName
            };
            return View(memberEdit);
        }
    }
}
