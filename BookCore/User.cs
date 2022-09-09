using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCore
{
    public class User 
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Age { get; set; }
        public char Gender{ get; set; }
        public string Adress { get; set; }
        public string ?AspUserId { get; set; }
    }
}
