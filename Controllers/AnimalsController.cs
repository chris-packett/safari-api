using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using safari_api.Models;

namespace safari_api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private SafariAdventureContext db { get; set; }

        public AnimalsController()
        {
            this.db = new SafariAdventureContext();
        }

        //GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            return this.db.Animals;
        }

        //POST api/animals
        [HttpPost]
        public ActionResult<Animal> Post([FromBody] string species)
        {
            var _animal = new Animal
            {
                Species = species,
                LocationOfLastSeen = "Outside",
            };

            this.db.Add(_animal);
            
            this.db.SaveChanges();

            return _animal;
        }
    }
}
