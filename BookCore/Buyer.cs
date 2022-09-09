using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCore
{
    public class Buyer : User
    {
        public int Id { get; set; }
        public ICollection<Book> ? books { set; get; }
        public string Ship_Adress { get; set; }
        public int Age { get; set; }


    }
}
