using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace VKBFrequencyAPI.Controllers
{
    [Route("api/[controller]")]
    public class DevController : Controller
    {
        private readonly FeedbackContext _ctx;

        public DevController(FeedbackContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _ctx.Feeds.OrderBy(x => x.Date);
            return Ok(data);
        }

        [HttpGet("{key}", Name="GetCount")]
        public IActionResult Get(int key)
        {
            var data = _ctx.Feeds.Find(key);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] FeedbackMod feedback)
        {
            if (feedback is null) return BadRequest();

            _ctx.Feeds.Add(feedback);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetCount", new { key = feedback.Key }, feedback);
        }
    }
}
