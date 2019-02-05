using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;
using UserStore.DAL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        //Task SetInitialData(UserDTO adminDto, List<string> roles);
        void AddVideo(Video video);
        void UpdateVideo(Video videoDTO);
        Video GetVideo(int? id);
        IEnumerable<Video> GetVideos();
        ApplicationUser GetApplicationUser(string UserId);
    } 
}
