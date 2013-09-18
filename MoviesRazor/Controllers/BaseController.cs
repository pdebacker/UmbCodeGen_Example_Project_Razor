using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MoviesRazor.Models;
using umbraco.NodeFactory;
using umbraco.interfaces;

namespace MoviesRazor.Controllers
{
    public class BaseController : Umbraco.Web.Mvc.RenderMvcController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewData.Add("MainMenu", this.Navigation());
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            // Because it is possible to inherit ModelBase from SiteModel additional site-wide model
            // information can be added to to each view model. This option is only usefull if every model should 
            // be extended with the same information. This is probably a rare situation. 
            // However this construction is an option to handle the site navigation.
            var view = filterContext.Result as ViewResult;
            if (view != null && view.ViewData.Model is SiteBase)
            {
                var model = view.ViewData.Model as SiteBase;
                model.Menu = Navigation();
            }
        }

        protected NavigationMenu Navigation()
        {
            Node node = new Node(1080);
            var mainMenu = ModelFactory.CreateModel<NavigationMenu>(node);
            DetermineCurrentItem(mainMenu);
            return mainMenu;
        }

        private void DetermineCurrentItem(NavigationMenu menu)
        {
            INode currentNode = Node.GetCurrent();
            while (currentNode != null)
            {
                foreach (var item in menu.MenuItems)
                {
                    if (item.HyperLink.NodeId == currentNode.Id)
                    {
                        item.Current = true;
                        return;
                    }
                }
                currentNode = currentNode.Parent;
            }
        }
    }
}
