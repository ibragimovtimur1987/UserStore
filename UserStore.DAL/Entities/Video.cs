using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.DAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public string Producer { get; set; }

        public string Author { get; set; }

        public int? Year { get; set; }

        public byte[] Poster { get; set; }

        public byte[] Content { get; set; }
    }
}
