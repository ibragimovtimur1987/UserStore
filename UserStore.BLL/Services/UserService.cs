using UserStore.BLL.DTO;
using UserStore.BLL.Infrastructure;
using UserStore.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using UserStore.BLL.Interfaces;
using UserStore.DAL.Interfaces;
using System.Collections.Generic;
using System;
using System.Web;
using System.IO;

namespace UserStore.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await Database.UserManager.CreateAsync(user, userDto.Password);
                // добавляем роль
              //  await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
              //  ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
              //  Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");

            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if(user!=null)
                claim= await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
        public ApplicationUser GetApplicationUser(string UserId)
        {
            // находим пользователя
            return Database.UserManager.FindById(UserId);
        }
        public IEnumerable<Video> GetVideos()
        {
            return Database.Videos.GetAll();
        }
        public void UpdateVideo(Video video)
        {
            if (video == null)
                throw new Exception("Видео не найдено");
            Database.Videos.Update(video);
            Database.Save();
        }
        public void AddVideo(Video video,string currentUserId, HttpPostedFileBase file)
        {
            // var user = GetApplicationUser(currentUserId);
            ApplicationUser currentUser = Database.UserManager.FindById<ApplicationUser, string>(currentUserId);
            video.Author = currentUser;
            video.Poster = file.InputStream.ToBytes() ;
            Database.Videos.Create(video);
            Database.Save();
        }
        public Video GetVideo(int? id)
        {
            if (id == null)
                throw new Exception("Видео не найдено");
            return Database.Videos.Get(id.Value);
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        //private string AddPosterFile(HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        using (var writer = new BinaryWriter(file.InputStream))
        //        {
        //            writer.Write(bytes);
        //        }
            
        //    var fileContent =;
        //        //string pathPoster = AppDomain.CurrentDomain.BaseDirectory + Constants.Path.PathPoster;
        //        //// получаем имя файла
        //        //string fileName = System.IO.Path.GetFileName(file.FileName);
        //        //string pathFile = Path.Combine(pathPoster, fileName);
        //        //file.SaveAs(pathFile);
        //        //return Constants.Path.PathPoster + file.FileName;
        //    }
        //    return "";
        //}

    }

    
}
