using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShoppingListBot.Models;

namespace ShoppingListBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static string current_list;
        public static int current_userId;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bot.GetBotClientAsync();
        }

        //public static void SetCurrentUser(int id)
        //{
        //    current_userId = id;
        //}


        //public static void SetCurrentList(string str)
        //{
        //    current_list = str;
        //}
    }
}
