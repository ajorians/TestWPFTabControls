using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_TabControl
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged( string prop )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
        }

        private string _exampleText = "ABC";
        public string ExampleText
        {
            get
            {
                return _exampleText;
            }
            set
            {
                if( value != _exampleText )
                {
                    _exampleText = value;
                    OnPropertyChanged( nameof( ExampleText ) );
                }
            }
        }

        private void AddNewGroup()
        {
            int a = 0;
            a++;
        }

        private ICommand _addNewGroupCommand;
        public ICommand AddNewGroupCommand => _addNewGroupCommand ?? ( _addNewGroupCommand = new RelayCommand( AddNewGroup, () => true ) );
    }
}
