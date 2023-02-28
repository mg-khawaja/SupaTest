using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SupaTest.Droid;
using SupaTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(NetWorkInfo))]
namespace SupaTest.Droid
{
    public class NetWorkInfo : INetWorkInfo
    {
        public string getSSID()
        {
            WifiManager wm = MainActivity.ThisActivity.GetSystemService(Context.WifiService) as WifiManager;
            WifiInfo info = wm.ConnectionInfo;
            if (info.HiddenSSID)
            {
                return info.IpAddress.ToString();
            }
            return info.SSID;
        }
    }
}