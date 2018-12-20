using Microsoft.EntityFrameworkCore;
using RdlNet2018.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNet2018.Data
{
    public class RdlNet2018DBInitializer
    {

        public void Seed(DbContext context)
        {

            List<ContentItem> ciList = new List<ContentItem>();

            ciList.Add(new ContentItem { Title = "Items Number One", Content = "<h1>This is Item One</h1><p>This is the text of this item. This is the content of this item.</p>" });
            ciList.Add(new ContentItem { Title = "Items Number Two", Content = "<h1>This is Item Two</h1><p>This is the text of this item. This is the content of this item.</p>" });
            ciList.Add(new ContentItem { Title = "Items Number Three", Content = "<h1>This is Item Three</h1><p>This is the text of this item. This is the content of this item.</p>" });
            ciList.Add(new ContentItem { Title = "Items Number Four", Content = "<h1>This is Item Four</h1><p>This is the text of this item. This is the content of this item.</p>" });
            ciList.Add(new ContentItem { Title = "Items Number Five", Content = "<h1>This is Item Five</h1><p>This is the text of this item. This is the content of this item.</p>" });

            Content cList = new Content { ContentItems = ciList, ContentOwner = "J. Reidell" };

            context.Add(cList);

            context.SaveChanges();

        }
    }
}
