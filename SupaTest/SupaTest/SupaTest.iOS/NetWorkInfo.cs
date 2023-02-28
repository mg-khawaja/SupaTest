using CoreLocation;
using Foundation;
using SupaTest.Helper;
using SupaTest.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using SystemConfiguration;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(NetWorkInfo))]
namespace SupaTest.iOS
{
    public class NetWorkInfo : INetWorkInfo
    {
        public string getSSID()
        {
            try
            {
                GetLocationConsent();
                NSDictionary dict;
                var status = CaptiveNetwork.TryCopyCurrentNetworkInfo("en0", out dict);

                if (status == StatusCode.NoKey)
                    return "";

                var bssid = dict[CaptiveNetwork.NetworkInfoKeyBSSID];
                var ssid = dict[CaptiveNetwork.NetworkInfoKeySSID];
                //var ssiddat = dict [CaptiveNetwork.NetworkInfoKeySSIDData];

                    return ssid.ToString();

                /*
			foreach (string intf in CaptiveNetwork.GetSupportedInterfaces()) {
				NSDictionary dict2;
				CaptiveNetwork.TryCopyCurrentNetworkInfo (intf, out dict2);

				//if (status == StatusCode.NoKey)
				//	return "";

				var bssid2 = dict [CaptiveNetwork.NetworkInfoKeyBSSID];
				var ssid2 = dict [CaptiveNetwork.NetworkInfoKeySSID];
				var ssiddat2 = dict [CaptiveNetwork.NetworkInfoKeySSIDData];
			}
			*/
            }
            catch
            {
                return "";
            }
        }
        private void GetLocationConsent()
        {
            var manager = new CLLocationManager();
            manager.AuthorizationChanged += (sender, args) => {
                Console.WriteLine("Authorization changed to: {0}", args.Status);
            };
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
                manager.RequestWhenInUseAuthorization();

        }
    }
}