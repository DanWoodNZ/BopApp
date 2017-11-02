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

namespace Bop
{
    [Activity(Label = "LocationActivity")]
    public class LocationViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LocationView);

            int rowNumber = Intent.GetIntExtra("rowNumber", 0);

                ImageButton backButton = FindViewById<ImageButton>(Resource.Id.backButton);
                backButton.Click += (s, e) =>
                {
                    Finish();
                };

                TextView about = FindViewById<TextView>(Resource.Id.aboutText);

                about.Text = ListViewActivity.locations[rowNumber].LocationDescription;

                TextView name = FindViewById<TextView>(Resource.Id.locationHeader);

                name.Text = ListViewActivity.locations[rowNumber].LocationName;

                ImageView locationImage = FindViewById<ImageView>(Resource.Id.locationPicture);

                locationImage.SetImageResource(ListViewActivity.locations[rowNumber].LocationImageUrl);
        }
    }
}