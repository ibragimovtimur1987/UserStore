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
    public class VideoRepository : IRepository<Video>
    {
        private ApplicationContext db;

        public VideoRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Video> GetAll()
        {
            return db.Videos;
        }

        public Video Get(int id)
        {
            return db.Videos.Find(id);
        }

        public void Create(Video video)
        {
            db.Videos.Add(video);
        }

        public void Update(Video video)
        {
            db.Entry(video).State = EntityState.Modified;
        }

        public IEnumerable<Video> Find(Func<Video, Boolean> predicate)
        {
            return db.Videos.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Video video = db.Videos.Find(id);
            if (video != null)
                db.Videos.Remove(video);
        }
    }
}
