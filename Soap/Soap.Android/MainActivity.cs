using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using static Soap.Droid.MainActivity;
using Soap.Models;
using Xamarin.Forms;

namespace Soap.Droid
{
    [Activity(Label = "Soap", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;




            base.OnCreate(bundle);
            Rg.Plugins.Popup.Popup.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }


        public class CloseApplication : ICloseApplication
        {
            public void closeApplication()
            {
                //var activity = (Activity)Forms.Context;
                //activity.FinishAffinity();

                // kill
                System.Diagnostics.Debug.WriteLine("Killing app");
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());


            }
            
        }

       
    }
}

