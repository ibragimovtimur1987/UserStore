using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStore.DAL.EF;
using UserStore.DAL.Entities;
using UserStore.Data.Interfaces;

namespace UserStore.DAL.Repositories
{
    public class UserRepository : IRepository<ApplicationUser,string>
    {
        private ApplicationContext db;

        public UserRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(ApplicationUser item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public ApplicationUser Get(string id)
        {
            var users = db.Users.ToList();
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ApplicationUser item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ApplicationUser> IRepository<ApplicationUser,string>.GetAll()
        {
            return db.Users;
        }
    }
}
