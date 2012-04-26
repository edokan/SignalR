using System;
using System.IO;
using Gate;
using Gate.Adapters.Nancy;
using Gate.Middleware;
using Owin;
using SignalR.Hosting.Owin;
using SignalR.Hubs;

namespace SignalR.Hosting.Owin.Nancy.Samples
{
    public class Startup
    {
        public static void Configuration(IAppBuilder builder)
        {

            builder
                .Use(LogToConsole)
                .UseShowExceptions()
                .UseSignalR("/signalr")
                .UseSignalR<RawConnection>("/Raw/Connection")
                .RunNancy();
        }

        public static AppDelegate Alias(AppDelegate app, string path, string alias)
        {
            return
                (env, result, fault) =>
                {
                    var req = new Request(env);
                    if (req.Path == path)
                    {
                        req.Path = alias;
                    }
                    app(env, result, fault);
                };
        }

        public static AppDelegate LogToConsole(AppDelegate app)
        {
            return
                (env, result, fault) =>
                {
                    var req = new Request(env);
                    Console.WriteLine(req.Method + " " + req.PathBase + req.Path);
                    app(env, result, fault);
                };
        }
    }
}