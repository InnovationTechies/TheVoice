using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;




namespace TheVoice
{
    [Activity(Label = "TheVoice", MainLauncher = true)]
    public class MainActivity : Activity
    {

        MediaPlayer _player;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _player = MediaPlayer.Create(this, Resource.Raw.test);
            var playButton = FindViewById<Button>(Resource.Id.playButton);
            playButton.Click += delegate {
                _player.Start();
            }

        protected void SaveVoice()
        {
            
        }

        protected void SearchNumber()
        {

        }
    }
}

