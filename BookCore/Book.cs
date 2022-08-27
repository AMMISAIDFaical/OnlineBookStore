using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCore
{
    public class Book
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        [ForeignKey("BuyerId")]
        public Buyer Buyer { set; get; }
        public int BuyerId { set; get; }
        [ForeignKey("SellerId")]
        public Seller Seller  { set; get; }
        public int SellerId { set; get; }

    }
}
