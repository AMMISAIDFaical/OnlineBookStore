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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]    
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        [ForeignKey("Buyer_Id")]
        public int Buyer_Id { get; set; }
        public Buyer Buyer { get; set; }
        [ForeignKey("Seller_Id ")]
        public int Seller_Id { get; set; }
        public Buyer Seller { get; set; }

    }
}
