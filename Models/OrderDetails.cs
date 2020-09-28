using BanckOfClothesServer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanckOfClothesServer.Models
{
    public class OrderDetails
    {
        [Key]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public Size Size { get; set; }
        public string ImagePath { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }
        public ProductStatus Status { get; set; }
        public Season Season { get; set; }
        public long Quantity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}