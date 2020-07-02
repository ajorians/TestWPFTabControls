using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_TabControl
{
   public class TimelineCollectionVM : INotifyPropertyChanged
   {
      public TimelineCollectionVM()
      {
         var mainTimeline = new TimelineVM()
         {
            Tab = new TimelineTabViewModel( 0 ){ Header= "Main Timeline", Permanent=true }
         };

         mainTimeline.CloseRequested += Timeline_CloseRequested;

         Timelines = new ObservableCollection<TimelineVM>()
         {
            mainTimeline
         };
      }

      private void Timeline_CloseRequested( object sender, EventArgs e )
      {
         TimelineVM closingTimeline = sender as TimelineVM;

         bool closingCurrentSelectedTab = Timelines[SelectedTabIndex] == closingTimeline;

         _ = Timelines.Remove( sender as TimelineVM );

         if ( closingCurrentSelectedTab )
         {
            int a= 0;
            a++;
            //SelectedTabIndex--;
         }
      }

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

      public void AddNewGroup( int id, string name )
      {
         var newTimeline = new TimelineVM()
         {
            Tab = new TimelineTabViewModel( id ) { Header = name, Permanent = false }
         };

         newTimeline.CloseRequested += Timeline_CloseRequested;

         Timelines.Add( newTimeline );

         SelectedTabIndex = Timelines.Count - 1;
      }

      private int _selectedTabIndex;

      public event PropertyChangedEventHandler PropertyChanged;

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
   }
}
