namespace MyShopOnline.Data.Entities
{
    public class Status
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
    }
}
