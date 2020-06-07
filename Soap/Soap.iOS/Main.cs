using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Foundation;
using Soap.Models;
using UIKit;

namespace Soap.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
        public class CloseApplication : ICloseApplication
        {
            public void closeApplication()
            {
               // Thread.CurrentThread.Abort();

                System.Diagnostics.Debug.WriteLine("Killing app");
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
            
        }

       


    }
}
