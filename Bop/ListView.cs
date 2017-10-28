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
using System.Collections;

namespace Bop
{
    public class  ListView : Activity
    {
        private List<Locations> locations;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Hard coded number of locations, to be replace when view is updated
            int numberOfLocations = 7;
            List<ImageButton> listLocations = new List<ImageButton>();

            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListView);

            //Hard coding adding the button events to location list items TRY TO REMOVE LATER
           
            listLocations.Add(FindViewById<ImageButton>(213427351));
            listLocations.Add(FindViewById<ImageButton>(213427352));
            listLocations.Add(FindViewById<ImageButton>(213427353));
            listLocations.Add(FindViewById<ImageButton>(213427354));
            listLocations.Add(FindViewById<ImageButton>(213427355));
            listLocations.Add(FindViewById<ImageButton>(213427356));
            listLocations.Add(FindViewById<ImageButton>(213427357));

            for (int i = 0; i <= numberOfLocations;i++)
            {
                listLocations[i].Click += (o, e) =>
                {
                    Toast.MakeText(this, "Pressed test1", ToastLength.Short).Show(); //When clicked, shows a toast message on screen
                };
            }
        }
    }
}