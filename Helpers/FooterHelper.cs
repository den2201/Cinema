using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Helpers
{
    public static class FooterHelper
    {
       public static MvcHtmlString Footer(this HtmlHelper helper, params string [] items)
        {
            var tag = new TagBuilder("footer");

            foreach(var item in items)
            {
                var p = new TagBuilder("p");
                p.SetInnerText(item);
                tag.InnerHtml += p.ToString();
            }
            return new MvcHtmlString( tag.ToString());

        }

    }
}