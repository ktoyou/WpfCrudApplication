using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.Models
{
    class Property : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}