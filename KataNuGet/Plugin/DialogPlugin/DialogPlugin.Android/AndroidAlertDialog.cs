using Android.App;
using Android.Content;
using DialogPlugin.Core;

namespace DialogPlugin.Android
{
    public class AndroidAlertDialog : IAlertDialog
    {
        private readonly Context _context;

        public AndroidAlertDialog(Context context)
        {
            _context = context;
        }

        public void Show(string title, string message)
        {
            new AlertDialog
            .Builder(_context)
            .SetTitle(title)
            .SetMessage(message)
            .SetPositiveButton("OK", (sender, args) => { })
            .Create()
            .Show();
        }
    }
}