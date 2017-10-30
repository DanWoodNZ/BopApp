using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Geolocator;
using System.Threading.Tasks;
using Android.Gms.Maps.Model;

namespace Bop
{
    public class UserLocationData
    {
        public UserLocationData()
        { }

        public LatLng GetUserPosition()
        {
            LatLng userLocation = null;

            Task.Run(async () =>
            {
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync(timeout);
                    Console.WriteLine("Position Status: {0}", position.Timestamp);
                    Console.WriteLine("Position Latitude: {0}", position.Latitude);
                    Console.WriteLine("Position Longitude: {0}", position.Longitude);
                    userLocation = new LatLng(position.Latitude, position.Longitude);
                }

                catch (Exception e)
                {

                }

            }).Wait();

            return userLocation;
        }

    }

}

