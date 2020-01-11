using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;


namespace Test1.Controllers
{
    public class CountryController : ApiController
    {
        // GET api/<controller>

        [HttpGet]
        public List<Country> Get()
        {

            Country c1 = new Country();
            return c1.getCountry();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpPut]
        public List<Country> Put(Country counteryToUpdate1)
        {
            Country counteryToUpdate  = new Country();
            counteryToUpdate1.PutCountry();
            return counteryToUpdate.getCountry();
        }



        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}