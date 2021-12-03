using System.Data.Entity;


namespace Handball_app_manager
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Handball> Handballs { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Player> Players { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }

    }
}
