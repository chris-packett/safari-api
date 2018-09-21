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

        //GET api/search?species=<<Species>>
        [HttpGet]
        public ActionResult<ResponseObject> Get([FromQuery] string species)
        {
            var _animal = this.db.Animals.FirstOrDefault(f => f.Species == species);

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _animal
            };

            return _rv;
        }
    }
}