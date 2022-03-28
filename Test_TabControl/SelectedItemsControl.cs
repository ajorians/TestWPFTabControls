using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Test_TabControl
{
class SelectedItemsControl : ItemsControl
{
   public int SelectedIndex
   {
      get => (int)GetValue( SelectedIndexProperty );
      set => SetValue( SelectedIndexProperty, value );
   }

   public static readonly DependencyProperty SelectedIndexProperty =
      DependencyProperty.Register( nameof( SelectedIndex ),
                                    typeof( int ),
                                    typeof( SelectedItemsControl ),
                                    new PropertyMetadata( 0, SelectedIndexChanged ) );

   private static void SelectedIndexChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
   {
      ( d as SelectedItemsControl ).SelectedItemChanged();
   }

   private void SelectedItemChanged()
   {
      for ( int itemIndex = 0; itemIndex < Items.Count; itemIndex++ )
      {
         object itemVM = Items[itemIndex];
         FrameworkElement itemContentPresenter = (FrameworkElement)ItemContainerGenerator.ContainerFromItem( itemVM );

         Visibility newVisibility = itemIndex == SelectedIndex ? Visibility.Visible : Visibility.Collapsed;

         itemContentPresenter.Visibility = newVisibility;
      }
   }
}
}
