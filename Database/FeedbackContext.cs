using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class FeedbackContext : DbContext
    {

        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {

        }

        public virtual DbSet<FeedbackMod> Feeds { get; set; }
    }
}
