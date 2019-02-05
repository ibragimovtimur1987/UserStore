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
using Microsoft.AspNet.Identity;
using System.IO;
using UserStore.Models;
using AutoMapper;

namespace UserStore.Web.Controllers
{
    [Authorize]
    public class VideoController : Controller
    {
        // GET: Video
        private IVideoService videoService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IVideoService>();
            }
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            string currentUser = User.Identity.GetUserId();
            List<VideoViewModel> videoViews = videoService.GetVideos().Select(x=>new VideoViewModel(x, currentUser)).ToList();
            return View(videoViews.ToPagedList(pageNumber, pageSize));
        }
        // Просмотр
        public ActionResult Details(int id)
        {
            Video video = videoService.GetVideo(id);
            VideoViewModel videoViewModel = new VideoViewModel(video);
            return PartialView("Details", videoViewModel);
        }
        // Добавление
        public ActionResult Create()
        {
            return PartialView("Create");
        }    
        // Добавление
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoViewModel videoViewModel, HttpPostedFileBase file)
        {
            Video video = videoViewModel.CreateVideo();
            videoService.AddVideo(video, User.Identity.GetUserId(), file);
            return RedirectToAction("Index");
        }
        // Редактирование
        public ActionResult Edit(int id)
        {
            Video video = videoService.GetVideo(id);
            Session["Poster"] = video.Poster;
            VideoViewModel videoViewModel = new VideoViewModel(video);
            return PartialView("Edit", videoViewModel);
        }
        //// Редактирование
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Edit(VideoViewModel videoViewModel, HttpPostedFileBase file)
        {
            Video video = videoViewModel.CreateVideo();
            if (file == null && Session["Poster"]!=null) video.Poster = (byte[])Session["Poster"];
            videoService.UpdateVideo(video, file);
            return RedirectToAction("Index");
        }
    }
}