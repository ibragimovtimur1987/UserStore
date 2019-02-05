using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserStore.Models
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public string Producer { get; set; }

        public int ApplicationUserId { get; set; }

        public int? Year { get; set; }

        public byte[] Poster { get; set; }

        public byte[] Content { get; set; }
    }
}