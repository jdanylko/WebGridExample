using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebGridExample.Models;

namespace WebGridExample.Helpers.Html
{
    public static class WebGridHelpers
    {
        public static HtmlString WebGridFilter<T>(this HtmlHelper helper, 
            IEnumerable<User> users, Func<User, string> property, 
            string headingText) where T: class
        {
            var model = new WebGridFilterModel
            {
                Users = users.GroupBy(property).Select(g=> g.First()),
                Property = property,
                HeadingText = headingText
            };
            return helper.Partial("_webGridFilter", model);
        }
    }
}