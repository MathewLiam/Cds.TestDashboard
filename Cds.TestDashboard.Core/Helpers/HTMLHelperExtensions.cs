namespace Cds.TestDashboard.Core.Helpers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper html)
        {
            string retVal = "";
            foreach (var key in html.ViewData.ModelState.Keys)
            {
                foreach (var err in html.ViewData.ModelState[key].Errors)
                    retVal += "<div class='alert alert-" + CssHelper.GetValidationSeverityStyle(key) + "' role='alert'>" + html.Encode(err.ErrorMessage) + "</div>";
            }

            MvcHtmlString element = new MvcHtmlString(retVal);

            return element;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}