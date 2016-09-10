using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using MvcPaging;

namespace WebGridExample.Helpers.Html
{
    public static class PagingExtensions
    {
        #region Set PageSize

        public static MvcHtmlString PageSizeSelector<T>(this HtmlHelper helper, 
            IPagedList<T> list) where T : class
        {
            var div = new TagBuilder("div");
            div.AddCssClass("btn-group");

            TagBuilder rowSelect = GetRowSelect(list);
            div.InnerHtml = String.Format("<label>Show Rows:</label>{0}", 
                rowSelect.ToString(TagRenderMode.Normal));

            return new MvcHtmlString(div.ToString(TagRenderMode.Normal));
        }

        private static TagBuilder GetRowSelect<T>(IPagedList<T> list)
        {
            var rowSelect = new TagBuilder("select");
            rowSelect.Attributes.Add("id", "size");
            rowSelect.Attributes.Add("name", "size");
            rowSelect.Attributes.Add("class", "size");
            // Define the amount of rows to return.
            var rows = new Dictionary<string, string>
                {
                    {"10", "10"},
                    {"25", "25"},
                    {"50", "50"},
                    {"100", "100"},
                    {"500", "500"}
                };

            var rowBuilder = new StringBuilder();
            foreach (var row in rows)
            {
                int count;
                if (!int.TryParse(row.Value, out count))
                {
                    count = 0;
                }
                rowBuilder.AppendFormat(
                    count == list.PageSize
                        ? "<option selected=\"selected\" value=\"{0}\">{1}</option>"
                        : "<option value=\"{0}\">{1}</option>", row.Value, row.Key);
            }
            rowSelect.InnerHtml = rowBuilder.ToString();

            return rowSelect;
        }

        #endregion

        #region Display Record Range

        public static MvcHtmlString PageRangeDisplay<T>(this HtmlHelper helper, IPagedList<T> list) where T : class
        {
            return MvcHtmlString.Create(GetRecordTotal(list).ToHtmlString());
        }

        private static MvcHtmlString GetRecordTotal<T>(IPagedList<T> list)
        {
            var recordTotal = new TagBuilder("label");

            var start = list.PageIndex * list.PageSize + 1;
            var end = start + list.PageSize - 1;
            if (end > list.TotalItemCount)
            {
                end = list.TotalItemCount;
            }
            recordTotal.InnerHtml = String.Format("{0}-{1} of {2}", start, end, list.TotalItemCount);

            return MvcHtmlString.Create(recordTotal.ToString(TagRenderMode.Normal));
        }

        #endregion

    }
}