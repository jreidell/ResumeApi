using System;

namespace RdlNet2018.Model
{
    public class ContentItem
    {
        public ContentItem()
        {
        }

        public int ContentItemId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string LinkUrl { get; set; }

        public string Author { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
