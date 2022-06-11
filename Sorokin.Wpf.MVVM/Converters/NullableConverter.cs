using System.Globalization;
using Sorokin.Wpf.MVVM.Core.Converter;

namespace Sorokin.Wpf.MVVM.Converters;

public class MultiNullableConverter : MultiConverterBase
{
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Any(item => item is null))
        {
            var unknown = new {};
            return true;
        }
        return false;

    }
}

public sealed class NullableConverter : ConverterBase
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is null;
}