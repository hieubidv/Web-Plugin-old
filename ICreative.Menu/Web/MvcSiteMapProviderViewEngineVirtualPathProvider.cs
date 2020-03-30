
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Web.Caching;
using System.Web.Hosting;

namespace ICreative.Menu.Web
{
    public class MvcSiteMapProviderViewEngineVirtualPathProvider : VirtualPathProvider
    {
        private bool PathExists(string path)
        {
            string resourceFileName = Path.GetFileName(path);
            Assembly assembly = typeof (MvcSiteMapProviderViewEngineVirtualFile).Assembly;
            return assembly.GetManifestResourceStream("ICreative.Menu.Web.Html.DisplayTemplates." + resourceFileName) !=
                   null;
        }

        public override bool FileExists(string virtualPath)
        {
            if (PathExists(virtualPath))
            {
                return true;
            }
            return base.FileExists(virtualPath);
        }


        public override VirtualFile GetFile(string virtualPath)
        {
            if (PathExists(virtualPath))
            {
                return new MvcSiteMapProviderViewEngineVirtualFile(virtualPath);
            }
            return base.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies,
            DateTime utcStart)
        {
            return null;
        }
    }
}