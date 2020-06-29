using System.ComponentModel;

namespace Test_TabControl
{
   public class TrackViewModel : INotifyPropertyChanged
   {
      public TrackViewModel()
      {
      }

      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged( string prop )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
      }

      public string Content { get; set; }

      private string _trackName;
      public string TrackName
      {
         get
         {
            return _trackName;
         }
         set
         {
            if ( value != _trackName )
            {
               _trackName = value;
               OnPropertyChanged( nameof( TrackName ) );
            }
         }
      }
   }
}