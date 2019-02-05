﻿using AutoMapper;
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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public byte[] Poster{ get; set; }

        public string ContentPath { get; set; }

        public ApplicationUser Author { get; set; }

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

        public Video GetVideo()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<VideoViewModel, Video>()).CreateMapper();
            return mapper.Map<VideoViewModel, Video>(this);
        }
    }
}