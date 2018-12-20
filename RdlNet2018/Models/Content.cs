using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RdlNet2018.Model
{
    public class Content
    {
        public int ContentId { get; set; }

        public string ContentOwner { get; set; }

        public virtual List<ContentItem> ContentItems { get; set; }

    }
}
