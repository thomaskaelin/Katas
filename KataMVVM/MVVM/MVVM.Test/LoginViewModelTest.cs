using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MVVM.Core;
using NUnit.Framework;

namespace MVVM.Test
{
    [TestFixture]
    public class LoginViewModelTest
    {
        private LoginViewModel _testee;
        private List<string> _propertyChangedEvents;
        private List<EventArgs> _canExecuteChangedEvents;

        [SetUp]
        public void Setup()
        {
            _testee = new LoginViewModel();
            _testee.PropertyChanged += DoOnPropertyChanged;
            _propertyChangedEvents = new List<string>();
            _canExecuteChangedEvents = new List<EventArgs>();

            _testee.LoginCommand.CanExecuteChanged += DoOnCanExecuteChanged;
        }

        private void DoOnCanExecuteChanged(object sender, EventArgs e)
        {
            _canExecuteChangedEvents.Add(e);
        }

        private void DoOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _propertyChangedEvents.Add(e.PropertyName);
        }

        [Test]
        public void Constructor_InitializesProperty()
        {
            _testee.Username.Should().Be(string.Empty);
            _testee.Password.Should().Be(string.Empty);
            _testee.LoginCommand.Should().NotBe(null);
        }

        [Test]
        public void Username_CanBeModified()
        {
            const string testeeUsername = "Username";
            _testee.Username = testeeUsername;

            var result = _testee.Username;
            result.Should().Be(testeeUsername);
        }

        [Test]
        public void Password_CanBeModified()
        {
            const string testeePassword = "Password";
            _testee.Password = testeePassword;

            var result = _testee.Password;
            result.Should().Be(testeePassword);
        }

        [Test]
        public void Username_WhenChanged_RaisesPropertyChangedEvent()
        {
            _testee.Username = "Username";
            _propertyChangedEvents.Count.Should().Be(1);
            _propertyChangedEvents.First().Should().Be(nameof(_testee.Username));
        }

        [Test]
        public void Password_WhenChanged_RaisesPropertyChangedEvent()
        {
            _testee.Password = "1234";
            _propertyChangedEvents.Count.Should().Be(1);
            _propertyChangedEvents.First().Should().Be(nameof(_testee.Password));
        }

        [Test]
        public void LoginCommandCanExecute_WhenUsernameIsEmpty_ReturnsFalse()
        {
            _testee.Username = string.Empty;

            var result = _testee.LoginCommand.CanExecute(null);
            result.Should().BeFalse();
        }

        [Test]
        public void LoginCommandCanExecute_WhenPasswordIsEmpty_ReturnsFalse()
        {
            _testee.Password = string.Empty;

            var result = _testee.LoginCommand.CanExecute(null);
            result.Should().BeFalse();
        }

        [Test]
        public void LoginCommandCanExecute_WhenPasswordAndUsernameNotEmpty_ReturnsTrue()
        {
            _testee.Username = "admin";
            _testee.Password = "1234";

            var result = _testee.LoginCommand.CanExecute(null);
            result.Should().BeTrue();
        }

        [Test]
        public void LoginCommandCanExecuteChanged_WhenUsernameChanged_IsRaised()
        {
            _testee.Username = "admin";

            var result = _canExecuteChangedEvents.Count;
            result.Should().Be(1);
        }

        [Test]
        public void LoginCommandCanExecuteChanged_WhenPasswordChanged_IsRaised()
        {
            _testee.Password = "1234";

            var result = _canExecuteChangedEvents.Count;
            result.Should().Be(1);
        }

        [Test]
        public void LoginCommandExecute_WhenUsernameAndPasswordCorrect_RaisesLoginSucceeded()
        {
            _testee.Username = "admin";
            _testee.Password = "1234";

            var loginSucceeded = false;
            _testee.LoginSucceeded += (sender, args) =>
            {
                loginSucceeded = true;
            };

            _testee.LoginCommand.Execute(null);
            loginSucceeded.Should().BeTrue();
        }

        [Test]
        public void LoginCommandExecute_WhenUsernameAndPasswordNotCorrect_LoginSucceededNotRaised()
        {
            _testee.Username = "admin";
            _testee.Password = "12";

            var loginSucceeded = false;
            _testee.LoginSucceeded += (sender, args) =>
            {
                loginSucceeded = true;
            };

            _testee.LoginCommand.Execute(null);
            loginSucceeded.Should().BeFalse();
        }
    }
}
