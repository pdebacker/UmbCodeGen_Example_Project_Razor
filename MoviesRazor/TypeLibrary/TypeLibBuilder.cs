using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.TypeLibrary
{
    using UmbCodeGen.TypeLib;
    using umbraco.cms.businesslogic.web;
    using Umbraco.Core;
    using Umbraco.Web;

    public class TypeLibraryBuilder : IApplicationEventHandler
    {

        #region IApplicationEventHandler Members

        public void OnApplicationInitialized(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
            this.httpApplication = httpApplication;
            this.applicationContext = applicationContext;

            umbraco.content.AfterRefreshContent += new umbraco.content.RefreshContentEventHandler(content_AfterRefreshContent);
        }

        public void OnApplicationStarting(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
        }
        #endregion

        private void content_AfterRefreshContent(Document sender, umbraco.cms.businesslogic.RefreshContentEventArgs e)
        {
            this.BuildDocumentTypeCache();
        }

        private void BuildDocumentTypeCache()
        {
            var typeLibrary = new DocumentTypeLibrary();
            typeLibrary.Build();
        }

        #region Private members

        private UmbracoApplicationBase httpApplication;
        private ApplicationContext applicationContext;

        #endregion
      
    }

}