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
         var mainTab = new TimelineTabViewModel(0)
         {
            Header= "Main Timeline",
            Permanent=true,
            TimelineVM = new TimelineVM()
         };

         mainTab.CloseRequested += Tab_CloseRequested;

         Tabs = new ObservableCollection<TimelineTabViewModel>()
         {
            mainTab
         };
      }

      private void Tab_CloseRequested( object sender, EventArgs e )
      {
         TimelineTabViewModel closingTab = sender as TimelineTabViewModel;

         bool closingCurrentSelectedTab = Tabs[SelectedTabIndex] == closingTab;

         _ = Tabs.Remove( sender as TimelineTabViewModel );

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

      private ObservableCollection<TimelineTabViewModel> _tabs;
      public ObservableCollection<TimelineTabViewModel> Tabs
      {
         get
         {
            return _tabs;
         }
         set
         {
            if ( value != _tabs )
            {
               _tabs = value;
               OnPropertyChanged( nameof( Tabs ) );
            }
         }
      }

      public void AddNewGroup( int id, string name )
      {
         var newTab = new TimelineTabViewModel(id )
         {
            Header = name,
            Permanent = false,
            TimelineVM = new TimelineVM() {  }
         };

         newTab.CloseRequested += Tab_CloseRequested;

         Tabs.Add( newTab );

         SelectedTabIndex = Tabs.Count - 1;
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
            }
         }
      }
   }
}
