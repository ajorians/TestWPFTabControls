using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Test_TabControl
{
    public class CustomTabControl : TabControl
    {
        // <summary>
        // TabHeadersVisibility Dependency Property
        // </summary>
        public static readonly DependencyProperty TabHeadersVisibilityProperty =
                DependencyProperty.Register( nameof( TabHeadersVisibility ),
                                            typeof( Visibility ),
                                            typeof( CustomTabControl ),
                                            new PropertyMetadata( Visibility.Visible ) );

        public Visibility TabHeadersVisibility
        {
            get { return (Visibility)GetValue( TabHeadersVisibilityProperty ); }
            set { SetValue( TabHeadersVisibilityProperty, value ); }
        }

        public static readonly DependencyProperty TabUnderlineBrushProperty =
                DependencyProperty.Register( nameof( TabUnderlineBrush ),
                                            typeof( Brush ),
                                            typeof( CustomTabControl ),
                                            new PropertyMetadata( null ) );

        public Brush TabUnderlineBrush
        {
            get { return (Brush)GetValue( TabUnderlineBrushProperty ); }
            set { SetValue( TabUnderlineBrushProperty, value ); }
        }
    }
}
