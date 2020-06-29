using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Test_TabControl
{
    public class GroupViewModel : INotifyPropertyChanged
    {
        private readonly IRemoveTabs _removeTabs;
        public GroupViewModel(IRemoveTabs removeTabs)
        {
            _removeTabs = removeTabs;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string prop )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
        }

        public string Content { get; set; }

        private string _header;
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                if ( value != _header )
                {
                    _header = value;
                    OnPropertyChanged( nameof( Header ) );
                }
            }
        }

        private void RemoveMyself()
        {
            _removeTabs.RemoveTab( this );
        }

        private ICommand _removeGroupCommand;
        public ICommand RemoveGroupCommand => _removeGroupCommand ?? ( _removeGroupCommand = new RelayCommand( RemoveMyself, () => true ) );

        private bool _allowClosing;
        public bool AllowClosing
        {
            get
            {
                return _allowClosing;
            }
            set
            {
                if( value != _allowClosing )
                {
                    _allowClosing = value;
                    OnPropertyChanged( nameof( AllowClosing ) );
                }
            }
        }
    }
}