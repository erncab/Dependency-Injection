using System.ComponentModel;

namespace DI.Autofac.WPF.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        
    }

    public abstract class ViewModelBase : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
