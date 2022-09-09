﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCore
{
    public class Seller : User
    {
        public int Id { get; set; }
        public ICollection<Book>? books { set; get; }
        public int Discount { get; set; }

    }
}
