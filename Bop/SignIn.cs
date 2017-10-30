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
    //[Activity(Label = "BopApp", MainLauncher = false)]
    public class SignIn : Activity
    {
        private Button signInButton, facebookButton, forgotPWButton, signUpButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Set our view from the "main" layout resource
            //SetContentView();

            forgotPWButton = FindViewById<Button>(Resource.Id.forgotPasswordButton);
            signInButton = FindViewById<Button>(Resource.Id.signInButton);
            facebookButton = FindViewById<Button>(Resource.Id.facebookButton);
            signUpButton = FindViewById<Button>(Resource.Id.signUpButton);
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

