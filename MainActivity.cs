using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using MwesoGameAndroid2D;
using Android.Media;

namespace MwesoGameAndroid
{
    [Activity(Label = "MwesoGameAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        LinearLayout mLinearLayout;
        private Button mBtnPlayGame;
        public EditText mUserName;
        private Button mBtnOption;
        MediaPlayer _player;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //Trying to add audio in the background
            _player = MediaPlayer.Create(this, Resource.Raw.sinach_rejoice_aac_21808);
            _player.Start();
            // Get our button from the layout resource,
            // and attach an event to it
            //Get a reference to the play button
            mBtnPlayGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            mUserName = FindViewById<EditText>(Resource.Id.userNametxt);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.MainView);
            mBtnOption = FindViewById<Button>(Resource.Id.btnOptions);
            mLinearLayout.Click += MLinearLayout_Click;

            mBtnPlayGame.Click += (object sender, EventArgs args) =>
            {

                Intent intent = new Intent(this, typeof(page2Activity));

                User user = new User()
                {
                    UserName = mUserName.Text
                };
                //displays the greeting message to the user with his name
                intent.PutExtra("UserName", "Hello " + user.UserName + " Welcome to Mweso Game 2D");
                this.StartActivity(intent);
                //second activty slides to the top and main activty slides to the bottom
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            };

        }

        private void MLinearLayout_Click(object sender, EventArgs e)
        {
            //Hide the keyboard when the sides are clicked on
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}

