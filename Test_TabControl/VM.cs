using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Test_TabControl
{
   public class VM : INotifyPropertyChanged, IRemoveTabs
   {
      public VM()
      {
         GroupTabs = new ObservableCollection<GroupViewModel>()
         {
               new GroupViewModel( this ){ Header= "Main Timeline", AllowClosing=false, LabelBrush = Brushes.White }
         };

         Timelines = new ObservableCollection<TimelineVM>()
         {
            new TimelineVM()
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

      private ObservableCollection<TimelineVM> _timelines;
      public ObservableCollection<TimelineVM> Timelines
      {
         get
         {
            return _timelines;
         }
         set
         {
            if ( value != _timelines )
            {
               _timelines = value;
               OnPropertyChanged( nameof( Timelines ) );
            }
         }
      }

      private int _selectedTabIndex;
      public int SelectedTabIndex
      {
         get
         {
            return _selectedTabIndex;
         }
         set
         {
            if ( value != _selectedTabIndex )
            {
               _selectedTabIndex = value;
               OnPropertyChanged( nameof( SelectedTabIndex ) );

               OnPropertyChanged( nameof( ActiveTimeline ) );
            }
         }
      }

      public TimelineVM ActiveTimeline
      {
         get
         {
            return Timelines[SelectedTabIndex];
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
         GroupTabs.Add( new GroupViewModel( this ) { Header = NewGroupName, AllowClosing = true, LabelBrush = Brushes.Green } );

         Timelines.Add( new TimelineVM() );

         SelectedTabIndex = GroupTabs.Count - 1;
      }

      public void RemoveTab( GroupViewModel groupViewModel )
      {
         GroupTabs.Remove( groupViewModel );
      }

      private ICommand _addNewGroupCommand;
      public ICommand AddNewGroupCommand => _addNewGroupCommand ?? ( _addNewGroupCommand = new RelayCommand( AddNewGroup, () => true ) );
   }
}
