using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Test_TabControl
{
   public class EqualityToVisibilityConverter : IMultiValueConverter
   {
      public object Convert( object[] values, Type targetType, object parameter, CultureInfo culture )
      {
         if ( values.All( x => x == values[0] ) )
            return Visibility.Visible;

         return Visibility.Collapsed;
      }
      public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture ) => throw new NotImplementedException();
   }
}
