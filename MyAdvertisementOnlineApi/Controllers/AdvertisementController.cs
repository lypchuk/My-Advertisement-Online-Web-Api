using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShopOnline.Data;
using MyShopOnline.Data.Entities;

namespace MyAdvertisementOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly MyShopOnlineDbContext context;

        public AdvertisementController(MyShopOnlineDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( context.Advertisements.Include(x => x.Category).Include(x => x.Status).Include(x => x.State).ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(context.Advertisements.Where(x=> x.ID == id).Include(x => x.Category).Include(x => x.Status).Include(x => x.State).ToList());
        }


        [HttpPost]
        public IActionResult Create(Advertisement item)
        {
            if(!ModelState.IsValid) 
            {
                return NotFound();
            }

            context.Advertisements.Add(item);
            context.SaveChanges();


            return Ok();
        }

    }
}
