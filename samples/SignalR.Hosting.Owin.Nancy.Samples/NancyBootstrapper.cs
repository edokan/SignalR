using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using System;
using System.IO;

namespace SignalR.Hosting.Owin.Nancy.Samples
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            var applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var contentFolder = Path.Combine(applicationBase, "Content");

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