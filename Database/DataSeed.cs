using Database.Models;
using System;
using System.Linq;

namespace Database
{
    public class DataSeed
    {

        // This class will be disabled in production // 

        private readonly FeedbackContext _ctx;

        public DataSeed(FeedbackContext ctx)
        {
            _ctx = ctx;
        }

      /*  public void SeedData()
        {
            if (!_ctx.Feeds.Any())
            {
                SeedFeeds();
                _ctx.SaveChanges();
            }
        }

        private void SeedFeeds()
        {
            var rndm = new Random();

            for (int i = 0; i < 4; i++)
            {
                _ctx.Feeds.Add(new FeedbackMod { Date = DateTime.Now.AddSeconds(i), Count = rndm.Next(50) });
            }
        }
        */
    }
}
