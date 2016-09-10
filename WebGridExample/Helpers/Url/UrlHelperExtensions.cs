using System.Web.Mvc;
using Microsoft.Owin;
using WebGridExample.Interface;

namespace WebGridExample.Helpers.Url
{
    public static class UrlHelperExtensions
    {
        public static string MainUrl(this UrlHelper helper, int size)
        {
            return helper.Content(string.Format("~/?size={0}", size));
        }
    }
}