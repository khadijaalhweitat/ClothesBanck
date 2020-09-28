using BanckOfClothesServer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanckOfClothesServer.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public  OrderStatus OrderStatus {get;set;}
    }
}