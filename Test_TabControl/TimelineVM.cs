using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Test_TabControl
{
   public class TimelineVM : INotifyPropertyChanged
   {
      //public event EventHandler<EventArgs> CloseRequested;
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

      private ICommand _addTrackCommand;
      public ICommand AddTrackCommand => _addTrackCommand ?? ( _addTrackCommand = new RelayCommand( AddTrack ) );

      private void AddTrack()
      {
         Tracks.Add( new TrackViewModel() { TrackName = "Track " + ( Tracks.Count + 1 ).ToString() } );
      }
   }
}
