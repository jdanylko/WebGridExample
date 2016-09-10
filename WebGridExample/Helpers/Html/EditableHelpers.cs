using System;
using System.Web.Mvc;
using WebGridExample.Models;

namespace WebGridExample.Helpers.Html
{
    public static class EditableHelpers
    {
        public static MvcHtmlString DisplayRecordOptions(this HtmlHelper helper, User user)
        {
            // Text Display
            var toolbar = new TagBuilder("ul");
            toolbar.AddCssClass("record-toolbar");

            var result = String.Concat(
                GetEditButton().ToString(TagRenderMode.Normal),
                GetSaveButton().ToString(TagRenderMode.Normal),
                GetCancelButton().ToString(TagRenderMode.Normal)
                );

            toolbar.InnerHtml = result;

            return MvcHtmlString.Create(toolbar.ToString(TagRenderMode.Normal));
        }

        private static TagBuilder GetEditButton()
        {
            var editButton = new TagBuilder("li")
            {
                InnerHtml = GetIcon("edit")
            };

            editButton.AddCssClass("edit-button btn btn-default btn-sm");
            editButton.Attributes.Add("title", "Edit Record");

            return editButton;
        }
        private static TagBuilder GetCancelButton()
        {
            var cancelButton = new TagBuilder("li")
            {
                InnerHtml = GetIcon("ban-circle")
            };

            cancelButton.AddCssClass("cancel-button hide btn btn-default btn-sm");
            cancelButton.Attributes.Add("title", "Cancel Editing");

            return cancelButton;
        }
        private static TagBuilder GetSaveButton()
        {
            var saveButton = new TagBuilder("li")
            {
                InnerHtml = GetIcon("floppy-disk")
            };

            saveButton.AddCssClass("save-button hide btn btn-default btn-sm");
            saveButton.Attributes.Add("title", "Save Record");

            return saveButton;
        }
        private static string GetIcon(string iconName)
        {
            var icon = new TagBuilder("i");
            icon.AddCssClass(String.Format("glyphicon glyphicon-{0}", iconName));

            return icon.ToString(TagRenderMode.Normal);
        }
    }
}