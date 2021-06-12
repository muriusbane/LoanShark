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

    }
}
