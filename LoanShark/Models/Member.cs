using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LoanShark.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
    }
}
