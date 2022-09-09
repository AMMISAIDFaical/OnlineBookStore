using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCore
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Book>  ? CartBook { get; set; }
        [ForeignKey("BuyerId")]
        public Buyer? Buyer { set; get; }
        public int? BuyerId { set; get; }

    }
}
