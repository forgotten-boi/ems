using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EMS.Website
{
    public static class HtmlHelperNavigation //: HtmlHelper
    {
        //public static HtmlHelperNavigation(ViewContext viewContext, IViewDataContainer viewDataContainer) : base(viewContext, viewDataContainer)
        //{
        //}

   
        //public static StringHtmlContent LiActionLink(this HtmlHelper html, string text, string action, string controller)
        //{
        //    action = action.ToLower();
        //    controller = controller.ToLower();
        //    var context = html.ViewContext;
        //    var controller = context.RouteData.Values["Controller"].ToString();

        //    if (context.Controller.ControllerContext.IsChildAction)
        //        context = html.ViewContext.ParentActionViewContext;
        //    var routeValues = context.RouteData.Values;
        //    var currentAction = routeValues["action"].ToString().ToLower();
        //    var currentController = routeValues["controller"].ToString().ToLower();

        //    var str = String.Format("<li role=\"presentation\"{0}>{1}</li>",
        //        currentAction.Equals(action, StringComparison.InvariantCulture) &&
        //        currentController.Equals(controller, StringComparison.InvariantCulture) ?
        //        " class=\"active\"" :
        //        String.Empty, html.ActionLink(text, action, controller).ToHtmlString()
        //    );
        //    return new MvcHtmlString(str);
        //}

    }
}