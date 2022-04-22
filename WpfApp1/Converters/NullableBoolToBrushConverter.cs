using System;
using System.Globalization;
using System.Windows.Media;
using Sorokin.Wpf.MVVM.Core.Converter;

namespace WpfApp1.Converters;

internal sealed class NullableBoolToBrushConverter : ConverterBase
{

    #region ConverterBase overrides

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is bool @bool))
        {
            throw new ArgumentException("value is not of type System.Bool", nameof(value));
        }

        return @bool ? Brushes.Magenta : Brushes.Lime;
    }

    #endregion
    
    
    
}