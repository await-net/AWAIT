 using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeleniumRecorderApi.Data;
using SeleniumRecorderApi.Models;

namespace SeleniumRecorderApi.Controllers
{
    
    [ApiController]
    [Route("[controller]",Name = "Selenium Recorder Api")]
    public class SeleniumTestController : Controller
    {
       private readonly SeleniumTestContext _context;

       public SeleniumTestController(SeleniumTestContext context)
       {
           _context = context;
       }

        // GET: SeleniumTestController/Details/5
        /// <summary>
        /// Gets the details of the test by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi =false)]
        [HttpGet]
        [Route("Details/{id}",Name = "Details")]
        public async Task<ActionResult> DetailsAsync(int id, [FromQuery] string accessToken)
        {
            if (!accessToken.Equals("c6a65832ffed4e01b088ca60507018f4"))
                return Unauthorized();
            var model = _context.SeleniumTest.Find(id);
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7140");
            var result = await httpClient.PostAsJsonAsync("/SeleniumTest", model);


            return Ok(model);
        }

        // GET: SeleniumTestController/Details/5
        [HttpPut]
        [Route("GetAccessToken", Name = "GetAccessToken")]
        public async Task<ActionResult> GetAccessTokenAsync(string username,string password)
        {

            if (username == "test" && password == "password")
                return Ok("c6a65832ffed4e01b088ca60507018f4");
            else
                return Unauthorized();
        }

        // POST: SeleniumTestController/Create
        [HttpPost]
        [Route("Create", Name = "Create")]
        public ActionResult Create([FromBody]SeleniumTestModel model, [FromQuery]string accessToken)
        {
            try
            {
                if (!accessToken.Equals("c6a65832ffed4e01b088ca60507018f4"))
                    return Unauthorized();
                _context.SeleniumTest.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
