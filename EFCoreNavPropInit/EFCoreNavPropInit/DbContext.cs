using Microsoft.EntityFrameworkCore;

namespace EFCoreNavPropInit
{
    class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
			: base(options)
		{
        }

        public DbSet<Entity> Entities => Set<Entity>();
        public DbSet<ChildEntity> ChildEntities => Set<ChildEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
