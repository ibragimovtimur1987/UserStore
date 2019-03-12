using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;
using UserStore.DAL.Entities;

namespace UserStore.BLL.Interfaces
{
    public interface IVideoService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        void AddVideo(Video video, string currentUserId, HttpPostedFileBase file);
        void UpdateVideo(Video video, HttpPostedFileBase file);
        Video GetVideo(int? id);
        IEnumerable<Video> GetVideos();
        ApplicationUser GetApplicationUser(string UserId);
    } 
}
