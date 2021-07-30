using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace EmailApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IStarterApp app = new MainApp();

            app.Start();
        }
    }
}
