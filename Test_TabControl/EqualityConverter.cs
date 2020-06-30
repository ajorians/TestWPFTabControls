using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Test_TabControl
{
   public class EqualityConverter : DependencyObject, IValueConverter
   {
      // <summary>
      // Invert Dependency Property
      // </summary>
      public static readonly DependencyProperty InvertProperty =
                DependencyProperty.Register( nameof( Invert ),
                                            typeof( bool ),
                                            typeof( EqualityConverter ),
                                            new PropertyMetadata( false ) );
      public bool Invert
      {
         get { return (bool)GetValue( InvertProperty ); }
         set { SetValue( InvertProperty, value ); }
      }

      public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
      {
         if ( value == null )
         {
            return ( parameter == null ) ^ Invert;
         }
         return value.Equals( parameter ) ^ Invert;
      }

      public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
      {
         return parameter;
      }
   }
}
