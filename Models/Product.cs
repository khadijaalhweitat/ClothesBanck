using BanckOfClothesServer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanckOfClothesServer.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public ProductCategory ProductCategory { get; set; }
    }
}