using Nancy;

namespace SignalR.Hosting.Owin.Nancy.Samples
{
    public class NancyApp : NancyModule
    {
        public NancyApp()
        {
            Get["/"] = _ =>
            {
                return View["index.html"];
            };

            Get["/{path}"] = x =>
            {
                var path = x.path;
                return View[path];
            };

            Get["/signalr"] = _ =>
            {
                return "we should be using signalr here!";
            };
            Get["/signalr/hubs"] = _ =>
            {
                return "we should be using signalr here!";
            };
        }
    }
}