using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Test_TabControl
{
   public class TimelineVM : INotifyPropertyChanged
   {
      public TimelineVM()
      {
         var random = new Random();
         int numTracks = random.Next( 500, 1000 );
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
