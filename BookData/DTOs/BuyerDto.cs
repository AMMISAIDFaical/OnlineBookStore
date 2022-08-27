using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookData.DTOs
{
    public class BuyerDto : UserDto
    {
        public int Id { get; set; }
        public string Ship_Adress { get; set; }

    }
}
