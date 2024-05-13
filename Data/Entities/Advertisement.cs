using System.ComponentModel.DataAnnotations;

namespace MyShopOnline.Data.Entities
{
    public class Advertisement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SellerName { get; set; }
        public string SellerPhone { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool InStock { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public string? ImageWay { get; set; }
        public string? ImageUrl { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Status? Status { get; set; }
        public int StatusId { get; set; }
        public State? State { get; set; }
        public int StateId { get; set; }
    }
}
