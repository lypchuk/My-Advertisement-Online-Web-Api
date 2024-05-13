namespace MyShopOnline.Data.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
    }
}
