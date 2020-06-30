using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Test_TabControl
{
   public class TimelineTabViewModel : INotifyPropertyChanged
   {
      public int Id { get; private set; }
      public event EventHandler<EventArgs> CloseRequested;
      public TimelineTabViewModel( int id )
      {
         Id = id;
      }

      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged( string prop )
      {
         PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( prop ) );
      }

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

      private void CloseTab()
      {
         CloseRequested?.Invoke( this, EventArgs.Empty );
      }

      private ICommand _closeTabCommand;
      public ICommand CloseTabCommand => _closeTabCommand ?? ( _closeTabCommand = new RelayCommand( CloseTab, () => !Permanent ) );

      private bool _permanent;
      public bool Permanent
      {
         get => _permanent;
         set
         {
            if( _permanent !=  value)
            {
               _permanent = value;
               OnPropertyChanged( nameof( Permanent ) );
            }
         }
      }
   }
}