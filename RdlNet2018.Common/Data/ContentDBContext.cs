using Microsoft.EntityFrameworkCore;
using RdlNet2018.Model;

namespace RdlNet2018.Data
{
    public class ContentDBContext : DbContext
    {

        public ContentDBContext(DbContextOptions<ContentDBContext> options) : base(options)
        {

            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Content> Content { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<RdlNet2018.Model.CareerInfo> CareerInfo { get; set; }
    }
}
