using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CloudPointCalc.Controllers
{

    [Route("api/[controller]")]
    public class CalcController : Controller
    {
        

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        [HttpPut]
        public void Put()
        {

        }




    }
}