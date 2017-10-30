using System;
using Android.Views;
using Android.Widget;

namespace Bop
{
    public class ImageHolder
    {
        public ImageView image { get; set; }


        public ImageHolder(View itemView)
        {

            image = itemView.FindViewById<ImageView>(Resource.Id.locationView);
        }

    }
}
