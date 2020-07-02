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
         TimelineCollection = new TimelineCollectionVM();
      }

      private int _nextID = 0;

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged( string prop )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
      }

      private TimelineCollectionVM _timelineCollection;
      public TimelineCollectionVM TimelineCollection
      {
         get
         {
            return _timelineCollection;
         }
         set
         {
            if ( value != _timelineCollection )
            {
               _timelineCollection = value;
               OnPropertyChanged( nameof( TimelineCollection ) );
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
         TimelineCollection.AddNewGroup( _nextID++, NewGroupName );

         NewGroupName = "Group " + TimelineCollection.Timelines.Count.ToString();
      }

      private ICommand _addNewGroupCommand;
      public ICommand AddNewGroupCommand => _addNewGroupCommand ?? ( _addNewGroupCommand = new RelayCommand( AddNewGroup, () => true ) );
   }
}
