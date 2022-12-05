namespace Project_WebApp.Models
{
    public class Receipt
    {
        public string? ReceiptID { get; set; }
        public int TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string? ItemID { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
