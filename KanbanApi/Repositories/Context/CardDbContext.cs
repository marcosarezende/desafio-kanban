using Microsoft.EntityFrameworkCore;

namespace KanbanApi.Repositories.Context
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Card> Cards { get; set; }
    }
}
