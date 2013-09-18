using System.Web.Mvc;

using Umbraco.Web.Models;

using umbraco.interfaces;
using umbraco.NodeFactory;

using MoviesRazor.Models;

namespace MoviesRazor.Controllers
{
    public class CinemasController : BaseController
    {

        public override ActionResult Index(RenderModel model)
        {
            INode currentNode = Node.GetCurrent();
            var cinemas = ModelFactory.CreateModel<Cinemas>(currentNode);

            return CurrentTemplate(cinemas);
        }

       
    }
}
