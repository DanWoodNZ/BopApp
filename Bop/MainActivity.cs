using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using System;
using System.Threading;
using Android;
using Android.Views.InputMethods;

namespace Bop
{
    [Activity(Label = "BopApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        static protected string signInEmail, signInPassword, signUpEmail, signUpPassword, signInConfirmPassword;
        private ImageButton signInButton, facebookButton, signUpButton;
        private Button forgotPWButton;
        private EditText emailField, password;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Set our view from the "main" layout resource
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.SignInView);
            emailField = FindViewById<EditText>(Resource.Id.emailField);
            password = FindViewById<EditText>(Resource.Id.passwordField);
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
                //Get entered field values
                signInEmail = emailField.Text;
                signInPassword = password.Text;
                //
                InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(emailField.WindowToken, 0);
                imm.HideSoftInputFromWindow(password.WindowToken, 0);
                if (signInEmail.Equals("guest") && signInPassword.Equals("guest"))
                {
                    //Dismiss Keybaord
                    
                    var intent = new Intent(this, typeof(MapActivity));
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(ApplicationContext, "Invalid login", ToastLength.Long).Show();
                }


            };

        }


        void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {




            //
        }

    }
}

