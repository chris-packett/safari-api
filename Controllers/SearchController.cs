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
    public class SearchController : ControllerBase
    {
        private SafariAdventureContext db { get; set; }

        public SearchController()
        {
            this.db = new SafariAdventureContext();
        }

        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public object Results { get; set; }
        }

        //GET api/search?species=<<Species>>&location=<<Location>>
        [HttpGet]
        public ActionResult<ResponseObject> Get([FromQuery] string species, string location)
        {
            var _rv = new ResponseObject();


            if (location != null && species != null)
            {
                var _animals = this.db.Animals.Where(f => f.LocationOfLastSeen == location);
                var _animalFromSpecificLocation = _animals.FirstOrDefault(f => f.Species == species);

                _rv.WasSuccessful = true;
                _rv.Results = _animalFromSpecificLocation;
            }
            else if (location != null || species != null)
            {
                if (location != null)
                {
                    var _animals = this.db.Animals.Where(f => f.LocationOfLastSeen == location);
                    _rv.WasSuccessful = true;
                    _rv.Results = _animals;
                }
                if (species != null)
                {
                    var _animal = this.db.Animals.FirstOrDefault(f => f.Species == species);
                    _rv.WasSuccessful = true;
                    _rv.Results = _animal;
                }
            }
            else
            {
                _rv.WasSuccessful = false;
                _rv.Results = new {
                    message = "Please make sure you use at least one URL paramater."
                };
            }

            return _rv;
        }
    }
}