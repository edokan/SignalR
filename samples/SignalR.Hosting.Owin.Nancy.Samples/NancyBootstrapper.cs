using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using System;
using System.IO;
using TinyIoC;

namespace SignalR.Hosting.Owin.Nancy.Samples
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        public class CustomRootPathProvider : IRootPathProvider
        {
            public string GetRootPath()
            {
                var applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                var viewsFolder = Path.Combine(applicationBase, "views");
                return viewsFolder;
            }
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            var applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var viewsFolder = Path.Combine(applicationBase, "views");
            var contentFolder = Path.Combine(viewsFolder, "Content");
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(contentFolder));
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                DiagnosticsConfiguration diagConfig = new DiagnosticsConfiguration();
                diagConfig.Password = "hellonancy";

                return diagConfig;
            }
        }
    }
}