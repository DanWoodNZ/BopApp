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
    [Activity(Label = "BopApp", MainLauncher = true)]
    public class SignIn : Activity
    {
        private Button mBtnSignUp, mBtnSignIn;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            //SetContentView();

            //mBtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
           // mBtnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            //mBtnSignUp.Click += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
             //  DialogSignUp dialogSignUp = new DialogSignUp();
               // dialogSignUp.Show(transaction, "dialog fragment");
              //  dialogSignUp.mOnSignUpComplete += signUpDialog_mOnSignUpComplete;
            };
            mBtnSignIn.Click += (object sender, EventArgs args) =>
            {
                //Pull up dialog
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogSignIn dialogSignIn = new DialogSignIn();
                dialogSignIn.Show(transaction, "dialog fragment");

                
            };
            
        }


        //void signUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        //{
          
            
            //throw new NotImplementedException();
       // }

   }
}

