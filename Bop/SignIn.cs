using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using System;
using System.Threading;
using Android;

namespace Bop
{
    [Activity(Label = "Bop", MainLauncher = true)]
    public class SignIn : Activity
    {
        private MainActivity mapView;
        private ImageButton signInButton, facebookButton, signUpButton;
        private Button forgotPWButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //mapView.StartActivity();
            //Set our view from the "main" layout resource
            //SetContentView();

            forgotPWButton = FindViewById<Button>(Resource.Id.forgotPasswordButton);
            signInButton = FindViewById<ImageButton>(Resource.Id.signInButton);
            facebookButton = FindViewById<ImageButton>(Resource.Id.facebookButton);
            signUpButton = FindViewById<ImageButton>(Resource.Id.signUpButton);
            signUpButton.Click += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignUp dialogSignUp = new DialogSignUp();
                dialogSignUp.Show(transaction, "dialog fragment");
                dialogSignUp.OnSignUpComplete += SignUpDialog_mOnSignUpComplete;
            };
            signInButton.Click += (object sender, EventArgs args) =>
            {
                //Sign in view transition             
            };
            
        }


        void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {           
            //
        }

   }
}

