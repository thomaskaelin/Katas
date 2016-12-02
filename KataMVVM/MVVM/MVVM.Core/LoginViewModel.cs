using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVM.Core
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler LoginSucceeded;

        public LoginViewModel()
        {
            _username = string.Empty;
            _password = string.Empty;
            LoginCommand = new Command(LoginCommandExecute, LoginCommandCanExecute);
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                    LoginCommand.OnCanExecuteChanged();
                }
                
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    LoginCommand.OnCanExecuteChanged();
                }
            }
        }

        public Command LoginCommand
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
