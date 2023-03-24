using Microsoft.AspNetCore.Mvc;
using WebApplication1.DA;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public List<Customers> Get()
        {
            var result=new Customers_DA().GetAll();
            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<Customers> Get(string id)
        {
            var result = new Customers_DA().GetByCustomerID(id);
            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
