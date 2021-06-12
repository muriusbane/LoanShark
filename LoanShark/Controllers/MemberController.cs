﻿using LoanShark.Data;
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
    }
}
