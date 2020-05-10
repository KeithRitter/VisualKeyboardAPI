using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace VKBFrequencyAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProdController : Controller
    {
        private readonly FeedbackContext _ctx;

        public ProdController(FeedbackContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _ctx.Feeds.OrderBy(x => x.Date);
            return Ok(data);
        }

        [HttpPost("add")]
        public void Post([FromBody] FeedbackMod feedback)
        {
            if (feedback is null) return;

            _ctx.Add(feedback);
            _ctx.SaveChanges();
        }

        [HttpPost("update")]
        public void Post([FromBody] EventHitModel hit)
        {
            if (hit is null) return;
            if (!hit.Hit) return;

            var latest = _ctx.Feeds.OrderByDescending(x => x.Key).FirstOrDefault();
            latest.Count++;
            _ctx.SaveChanges();
        }

        [HttpDelete]
        public void Delete()
        {
            var latest = _ctx.Feeds;
            foreach (var del in latest)
            {
                latest.Remove(del);
            }
            _ctx.SaveChanges();
        }
    }
}
