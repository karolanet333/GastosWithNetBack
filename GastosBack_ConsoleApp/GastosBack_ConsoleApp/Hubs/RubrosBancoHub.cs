
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastosBack_ConsoleApp.Hubs
{
    [HubName("rubrosBancoHub")]
    public class RubrosBancoHub : Hub
    {
        public static void Changed()
        {


            //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<RubrosBancoHub>();
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<RubrosBancoHub>();
            
            context.Clients.All.rubrosBancoListChanged();

            //this.Clients.All.rubrosBancoListChanged(_hitCount);
        }
    }
}