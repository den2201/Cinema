using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace Cinema.Helpers
{
    public static class FooterHelper
    {
        public static Microsoft.AspNetCore.Html.HtmlString Footer(this IHtmlHelper helper, params string [] items)
        {
            var footer = new TagBuilder("footer");
            foreach(var item in items)
            {
                var p = new TagBuilder("p");
                p.InnerHtml.Append(item);
                footer.InnerHtml.AppendHtml(p);
            }
            var writer = new System.IO.StringWriter();
            footer.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
