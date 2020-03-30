
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace ICreative.Menu.Web
{
    internal class MvcSiteMapProviderViewEngineVirtualFile : VirtualFile
    {
        public MvcSiteMapProviderViewEngineVirtualFile(string filePath)
            : base(filePath)
        {
            FilePath = filePath;
        }

        protected string FilePath { get; private set; }

        public override Stream Open()
        {
            return ReadResource(FilePath);
        }

        private static Stream ReadResource(string embeddedFileName)
        {
            string resourceFileName = Path.GetFileName(embeddedFileName);
            Assembly assembly = typeof (MvcSiteMapProviderViewEngineVirtualFile).Assembly;
            return assembly.GetManifestResourceStream("ICreative.Menu.Web.Html.DisplayTemplates." + resourceFileName);
        }
    }
}