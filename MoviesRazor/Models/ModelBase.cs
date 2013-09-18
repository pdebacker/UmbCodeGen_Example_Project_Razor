using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Models;

namespace MoviesRazor.Models
{
    public class SiteBase
    {
        public NavigationMenu Menu { get; set; }
    }

    // Because it is possible to inherit ModelBase from SiteModel additional site-wide model
    // information can be added to to each view model. This option is only usefull if every model should 
    // be extended with the same information. This is probably a rare situation. 
    // However this construction is an option to handle the site navigation.
    public abstract partial class ModelBase : SiteBase
    {

    }
}