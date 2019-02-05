using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserStore.DAL.Entities;

namespace UserStore.Models
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public string Producer { get; set; }

        public int? Year { get; set; }

        public string PosterPath { get; set; }

        public string ContentPath { get; set; }

        public ApplicationUser Author { get; set; }
        public VideoViewModel()
        {

        }
        public VideoViewModel(Video video)
        {
            Id = video.Id;
            Title = video.Title;
            Note = video.Note;
            Producer = video.Producer;
            Year = video.Year;
            PosterPath = video.PosterPath;
            ContentPath = video.ContentPath;
            Author = video.Author;
        }
        public Video GetVideo()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VideoViewModel, Video>()).CreateMapper();
            return mapper.Map<VideoViewModel, Video>(this);
        }
    }
}