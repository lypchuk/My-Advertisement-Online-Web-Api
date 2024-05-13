using Microsoft.AspNetCore.Identity;

namespace MyShopOnline.Data.Entities
{
    public class User:IdentityUser
    {
        public DateTime? Birthdate { get; set; }
    }
}
