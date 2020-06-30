using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Test_TabControl
{
   public class TimelineVM : INotifyPropertyChanged
   {
      public event EventHandler<EventArgs> CloseRequested;
      public TimelineVM()
      {
         var random = new Random();
         //int numTracks = random.Next( 1500, 5000 );
         int numTracks = random.Next( 1, 5 );
         Tracks = new ObservableCollection<TrackViewModel>();
         for(int i=0; i< numTracks; i++ )
         {
            Tracks.Add( new TrackViewModel() { TrackName = "Track " + ( i + 1 ).ToString() } );
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged( string prop )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
      }

      private TimelineTabViewModel _tab;
      public TimelineTabViewModel Tab
      {
         get
         {
            return _tab;
         }
         set
         {
            if ( value != _tab )
            {
               _tab = value;
               OnPropertyChanged( nameof( Tab ) );

               Tab.CloseRequested += Tab_CloseRequested;
            }
         }
      }

      private void Tab_CloseRequested( object sender, EventArgs e )
      {
         CloseRequested?.Invoke( this, EventArgs.Empty );
      }

      private ObservableCollection<TrackViewModel> _tracks;
      public ObservableCollection<TrackViewModel> Tracks
      {
         get
         {
            return _tracks;
         }
         set
         {
            if ( value != _tracks )
            {
               _tracks = value;
               OnPropertyChanged( nameof( Tracks ) );
            }
         }
      }
   }
}
