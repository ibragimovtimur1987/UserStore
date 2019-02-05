using UserStore.BLL.Interfaces;
using UserStore.DAL.Repositories;

namespace UserStore.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IVideoService CreateUserService(string connection)
        {
            return new VideoService(new IdentityUnitOfWork(connection));
        }
    }
}
