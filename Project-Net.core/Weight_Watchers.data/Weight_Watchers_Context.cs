using Microsoft.EntityFrameworkCore;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.data
{
    public class Weight_Watchers_Context:DbContext
    {
        public Weight_Watchers_Context(DbContextOptions<Weight_Watchers_Context> options):base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
    
}