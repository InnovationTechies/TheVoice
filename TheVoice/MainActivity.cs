using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using TheVoice;

using System.IO;
//Add class variables
//for a MediaRecorder and MediaPlayer.and Also add class variables
//for the buttons so we can start and stop.




namespace TheVoice
{
    [Activity(Label = "TheVoice", MainLauncher = true)]
    public class MainActivity : Activity
    {

        MediaRecorder _recorder;
        MediaPlayer _player;
        Button _start;
        Button _stop;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //_player = MediaPlayer.Create(this,Android.Net.Uri.FromFile());
            //var playButton = FindViewById<Button>(Resource.Id.btnSearch);
            //playButton.Click += delegate
            //{
            //    _player.Start();
            //    //};


            //    protected override void OnCreate(Bundle bundle)
            //{
            //    base.OnCreate(bundle);
            // Set our view from the "main" layout resource  

            _start = FindViewById<Button>(Resource.Id.start);
            _stop = FindViewById<Button>(Resource.Id.stop);
            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.3gpp";

            _start.Click += delegate
            {
                _stop.Enabled = !_stop.Enabled;
                _start.Enabled = !_start.Enabled;
                _recorder.SetAudioSource(AudioSource.Mic);
                _recorder.SetOutputFormat(OutputFormat.Default);
                _recorder.SetAudioEncoder(AudioEncoder.Default);
                _recorder.SetOutputFile(path);
                _recorder.Prepare();
                _recorder.Start();
            };
            _stop.Click += delegate
            {
                _stop.Enabled = !_stop.Enabled;
                _recorder.Stop();
                _recorder.Reset();
                _player.SetDataSource(path);
                _player.Prepare();
                _player.Start();
            };
        }



        protected override void OnResume()
        {
            base.OnResume();
            _recorder = new MediaRecorder();
            _player = new MediaPlayer();
            _player.Completion += (sender, e) =>
            {
                _player.Reset();
                _start.Enabled = !_start.Enabled;
            };
        }
        protected override void OnPause()
        {
            base.OnPause();
            _player.Release();
            _recorder.Release();
            _player.Dispose();
            _recorder.Dispose();
            _player = null;
            _recorder = null;
        }
        protected void SaveVoice()
        {

        }

        protected void SearchNumber()
        {

        }
    }
}

