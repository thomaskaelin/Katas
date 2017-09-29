using System.ComponentModel;

namespace KataAOP
{
    public class PropertyChanger : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string FullName => $"{GivenName} {FamilyName}";
    }
}
