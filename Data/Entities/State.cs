namespace MyShopOnline.Data.Entities
{
    public class State
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
    }
}
