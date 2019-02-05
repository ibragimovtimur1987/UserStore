using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using UserStore.DAL.Entities;

namespace UserStore.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new StoreDbInitializer());
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
        {
            protected override void Seed(ApplicationContext db)
            {
                //for (int i = 0; i < 20; i++)
                //{
                //    string title = "Фильм " + i.ToString();
                //    string note = "Описание " + i.ToString(); ;
                //    string producer = "Режиссёр " + i.ToString();
                //    db.Videos.Add(new Video { Title = title, Note = note, Producer = producer });
                //}
                //db.SaveChanges();
            }
        }
    }
}
