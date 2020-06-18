using System.ComponentModel;

namespace Test_TabControl
{
    public class GroupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string prop )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
        }

        //public string Header { get; set; }
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
    }
}