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

        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public object Results { get; set; }
        }

        //GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            return this.db.Animals;
        }

        //GET api/animals/search?species=<<Species>>
        [HttpGet]
        [Route("search")]
        public ActionResult<ResponseObject> Get([FromQuery] string species)
        {
            var _animal = this.db.Animals.Where(f => f.Species == species).First();

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _animal
            };

            return _rv;
        }

        //POST api/animals
        [HttpPost]
        public ActionResult<Animal> Post([FromBody] Animal animal)
        {
            var _animal = new Animal
            {
                Species = animal.Species,
                LocationOfLastSeen = animal.LocationOfLastSeen,
            };

            this.db.Add(_animal);

            this.db.SaveChanges();

            return _animal;
        }

        //GET api/animals/{location}
        [HttpGet("{location}")]
        public ActionResult<ResponseObject> GetByLocation(string location)
        {
            var _animal = this.db.Animals.FirstOrDefault(f => f.LocationOfLastSeen == location);

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _animal
            };

            return _rv;
        }

        //PUT api/animals/{species}
        [HttpPut("{species}")]
        public ActionResult<ResponseObject> Put(string species)
        {
            var _animal = this.db.Animals.FirstOrDefault(f => f.Species == species);

            _animal.CountOfTimesSeen = _animal.CountOfTimesSeen + 1;

            this.db.SaveChanges();

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _animal
            };

            return _rv;
        }

        //DELETE api/animals/{species}
        [HttpDelete("{species}")]
        public ActionResult<ResponseObject> Delete(string species)
        {
            var _animal = this.db.Animals.FirstOrDefault(f => f.Species == species);

            this.db.Remove(_animal);

            this.db.SaveChanges();

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _animal
            };

            return _rv;
        }
    }
}
