namespace Project_WebApp.Models
{
    public class Receipt
    {
        public Guid ReceiptID { get; set; }
        public int TotalAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
