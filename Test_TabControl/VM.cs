using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_TabControl
{
    public class VM : INotifyPropertyChanged
    {
        public VM()
        {
            GroupTabs = new ObservableCollection<GroupViewModel>()
            {
                new GroupViewModel(){ Header= "Main Timeline", AllowClosing=false }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged( string prop )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
        }

        private ObservableCollection<GroupViewModel> _groupTabs;
        public ObservableCollection<GroupViewModel> GroupTabs
        {
            get
            {
                return _groupTabs;
            }
            set
            {
                if ( value != _groupTabs )
                {
                    _groupTabs = value;
                    OnPropertyChanged( nameof( GroupTabs ) );
                }
            }
        }

        private string _newGroupName = "Group 1";
        public string NewGroupName
        {
            get
            {
                return _newGroupName;
            }
            set
            {
                if ( value != _newGroupName )
                {
                    _newGroupName = value;
                    OnPropertyChanged( nameof( NewGroupName ) );
                }
            }
        }

        private void AddNewGroup()
        {
            GroupTabs.Add( new GroupViewModel() { Header = NewGroupName, AllowClosing = true } );
        }

        private ICommand _addNewGroupCommand;
        public ICommand AddNewGroupCommand => _addNewGroupCommand ?? ( _addNewGroupCommand = new RelayCommand( AddNewGroup, () => true ) );
    }
}
