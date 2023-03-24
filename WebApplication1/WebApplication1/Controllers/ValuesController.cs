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
        public string Post([FromBody] Customers value)
        {
            var result=new Customers_DA().InsertData(value);
            if (result == 1)
            {
                return "客戶編號: " + value.CustomerID + " 新增成功";
            }
            else { return "新增失敗"; }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] Customers value)
        {
            //確認編號是否存在
            if(new Customers_DA().GetByCustomerID(id).Count == 0) 
            { return "無此客戶編號"; }
            var result = new Customers_DA().UpdateData(id,value);
            if (result == 1)
            {
                return "客戶編號: " + value.CustomerID + " 修改成功";
            }
            else { return "修改失敗"; }


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
