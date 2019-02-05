using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserStore.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, string src, string alt)
        {
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", src);
            img.MergeAttribute("alt", alt);

            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }
    }
}