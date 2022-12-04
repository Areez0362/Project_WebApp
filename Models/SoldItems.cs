﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Project_WebApp.Models
{
    public class SoldItems
    {
        public Guid ItemID { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Receipt")]
        public Guid ReceiptID { get; set; }
        public virtual Receipt? Receipt { get; set; }
    }
}
