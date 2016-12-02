using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVM.Core
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public event EventHandler LoginSucceeded;

        public LoginViewModel()
        {
            _username = string.Empty;
            _password = string.Empty;
            LoginCommand = new RelayCommand(LoginCommandExecute, LoginCommandCanExecute);
        }

        private bool LoginCommandCanExecute()
        {
            return Username != string.Empty && Password != string.Empty ;
        }

        private void LoginCommandExecute()
        {
            if (Username == "admin" && Password == "1234")
            {
                OnLoginSucceeded();
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (Set(ref _username, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
                
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (Set(ref _password, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand LoginCommand
        {
            get;
            private set;
        }

        protected virtual void OnLoginSucceeded()
        {
            LoginSucceeded?.Invoke(this, EventArgs.Empty);
        }
    }
}
