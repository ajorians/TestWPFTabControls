using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Test_TabControl
{
   public class VM : INotifyPropertyChanged
   {
      public VM()
      {
         var mainTimeline = new TimelineVM()
         {
            Tab = new TimelineTabViewModel( _nextID++ ){ Header= "Main Timeline", Permanent=true }
         };

         mainTimeline.CloseRequested += Timeline_CloseRequested;

         Timelines = new ObservableCollection<TimelineVM>()
         {
            mainTimeline
         };
      }

      private void Timeline_CloseRequested( object sender, EventArgs e )
      {
         _ = Timelines.Remove( sender as TimelineVM );
      }

      private int _nextID = 0;

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged( string prop )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
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
            if ( SelectedTabIndex < 0 || SelectedTabIndex >= Timelines.Count )
            {
               return null;
            }

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
         var newTimeline = new TimelineVM()
         {
            Tab = new TimelineTabViewModel( _nextID++ ) { Header = NewGroupName, Permanent = false }
         };

         newTimeline.CloseRequested += Timeline_CloseRequested;

         Timelines.Add( newTimeline );

         SelectedTabIndex = Timelines.Count - 1;

         NewGroupName = "Group " + Timelines.Count.ToString();
      }

      private ICommand _addNewGroupCommand;
      public ICommand AddNewGroupCommand => _addNewGroupCommand ?? ( _addNewGroupCommand = new RelayCommand( AddNewGroup, () => true ) );
   }
}
