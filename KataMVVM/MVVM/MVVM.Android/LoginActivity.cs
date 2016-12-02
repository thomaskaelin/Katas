using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using MVVM.Core;

namespace MVVM.Android
{
    [Activity(Label = "MVVM.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<EditTextBinding> _bindings = new List<EditTextBinding>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Login);

            var viewModel = new LoginViewModel();

            var usernameEditText = FindViewById<EditText>(Resource.Id.usernameEditText);
            var passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            var loginButton = FindViewById<Button>(Resource.Id.loginButton);

            _bindings.Add(new EditTextBinding(
                viewModel, 
                nameof(viewModel.Username), 
                usernameEditText, 
                nameof(usernameEditText.Text)));

            _bindings.Add(new EditTextBinding(
                viewModel,
                nameof(viewModel.Password),
                passwordEditText,
                nameof(passwordEditText.Text)));

            loginButton.Click += (sender, args) =>
            {
                viewModel.Username = "Hallo Welt";
                viewModel.Password = "Cool!";
            };
        }
    }
}

