using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserStore.DAL.Entities;

namespace UserStore.Models
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        [Required]
        public string Note { get; set; }
        [Display(Name = "Режиссёр")]
        [Required]
        public string Producer { get; set; }
        [Display(Name = "Год выпуска")]
        [Required]
        public int? Year { get; set; }
        [Display(Name = "Постер")]
        [Required]
        public byte[] Poster{ get; set; }

        public string ContentPath { get; set; }

        public ApplicationUser Author { get; set; }

        [Display(Name = "Опубликовал")]
        public string AuthorUserName { get; set; }

        public bool IsAuthor { get; set; }

        public VideoViewModel()
        {

        }
        public VideoViewModel(Video video)
        {
            FillFields(video);
        }

        public VideoViewModel(Video video,string currentUserId)
        {
            FillFields(video);
            IsAuthor = Author?.Id == currentUserId;
        }

        private void FillFields(Video video)
        {
            Id = video.Id;
            Title = video.Title;
            Note = video.Note;
            Producer = video.Producer;
            Year = video.Year;
            Poster = video.Poster;
            ContentPath = video.ContentPath;
            Author = video?.Author;
            AuthorUserName = video?.Author?.UserName;
        }

        public Video CreateVideo()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VideoViewModel, Video>()).CreateMapper();
            return mapper.Map<VideoViewModel, Video>(this);
        }
    }
}