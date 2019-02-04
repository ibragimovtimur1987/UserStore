using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStore.BLL.Interfaces;
using PagedList;
using PagedList.Mvc;
using UserStore.DAL.Entities;
using Microsoft.AspNet.Identity.Owin;

namespace UserStore.Web.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        private IUserService videoService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
            public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var videos = videoService.GetVideos().ToList();
            return View(videos.ToPagedList(pageNumber, pageSize));
        }
        //// Просмотр подробных сведений о книге
        public ActionResult Details(int id)
        {
            Video video = videoService.GetVideo(id);
            return PartialView("Details", video);
        }
        // Добавление
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        // Редактирование
        public ActionResult Edit(int id)
        {
            Video video = videoService.GetVideo(id);
            return PartialView("Edit", video);
        }
        // Добавление
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Video video)
        {
            videoService.AddVideo(video);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //// Редактирование
        public ActionResult Edit(Video video)
        {
            videoService.UpdateVideo(video);
            return RedirectToAction("Index");
        }
    }
}