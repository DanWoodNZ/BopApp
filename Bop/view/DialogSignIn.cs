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

namespace BopApp
{
    class DialogSignIn : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_sign_in, container, false);
            return view;
        }
        public override void OnActivityCreated(Bundle savedInstancesState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);//removes title bar
            base.OnActivityCreated(savedInstancesState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;//animation set
        }
        
    }
}