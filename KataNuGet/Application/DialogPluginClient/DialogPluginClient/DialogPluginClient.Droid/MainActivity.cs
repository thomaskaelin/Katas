using Android.App;
using Android.Widget;
using Android.OS;
using DialogPlugin.Android;

namespace DialogPluginClient.Droid
{
	[Activity (Label = "DialogPluginClient.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var button = FindViewById<Button> (Resource.Id.myButton);

		    var androidAlert = new AndroidAlertDialog(this);
		    var sharedClass = new ClassInSharedCode(androidAlert);

            button.Click += delegate {
                sharedClass.Show();

            };
		}
	}
}


