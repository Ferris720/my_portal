using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Diplom.Hubs.SignalRChat))]

namespace Diplom.Hubs
{
    public class SignalRChat
    {
        public void Configuration(IAppBuilder app)
        { 
            app.MapSignalR();
        }
    }
}
