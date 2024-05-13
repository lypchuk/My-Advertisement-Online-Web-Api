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
            var entity = context.Advertisements.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            //return Ok(entity);

            return Ok(context.Advertisements.Where(x=> x.ID == id).Include(x => x.Category).Include(x => x.Status).Include(x => x.State).ToList());
        }


        [HttpPost]
        public IActionResult Create(Advertisement model)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }

            context.Advertisements.Add(model);
            context.SaveChanges();


            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Advertisement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var entity = context.Advertisements.AsNoTracking().FirstOrDefault(x => x.ID == model.ID);

            if (entity == null)
            {
                return NotFound();
            }

            context.Advertisements.Update(model);
            context.SaveChanges();


            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var entity = context.Advertisements.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            context.Advertisements.Remove(entity);
            context.SaveChanges();


            return Ok();
        }

    }
}
