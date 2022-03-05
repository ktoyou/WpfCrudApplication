using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
