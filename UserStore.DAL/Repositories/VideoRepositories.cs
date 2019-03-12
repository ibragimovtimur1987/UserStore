using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;
using UserStore.Data.Interfaces;

namespace UserStore.DAL.Repositories
{
    public class VideoRepository : IRepository<Video,int>
    {
        private ApplicationContext db;

        public VideoRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IQueryable<Video> GetAll()
        {
            return db.Videos.AsNoTracking().Include("Author").AsQueryable();
        }

        public Video Get(int id)
        {
            return db.Videos.AsNoTracking().Include("Author").FirstOrDefault(x=>x.Id == id);
        }

        public void Create(Video video)
        {
            db.Videos.Add(video);
        }

        public void Update(Video video)
        {
            db.Videos.Attach(video);
            db.Entry(video).Property(x => x.Note).IsModified = true;
            db.Entry(video).Property(x => x.Producer).IsModified = true;
            db.Entry(video).Property(x => x.Title).IsModified = true;
            db.Entry(video).Property(x => x.Year).IsModified = true;
        }

        public IQueryable<Video> Find(Func<Video, Boolean> predicate)
        {
            return db.Videos.AsNoTracking().Where(predicate).AsQueryable();
        }

        public void Delete(int id)
        {
            Video video = db.Videos.Find(id);
            if (video != null)
                db.Videos.Remove(video);
        }
    }
}
