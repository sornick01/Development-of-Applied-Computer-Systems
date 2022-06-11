﻿using System.Globalization;
using System.Windows;
using Sorokin.Wpf.MVVM.Core.Converter;

namespace Sorokin.Wpf.MVVM.Convertors;

public class MultiLogicalConverter : MultiConverterBase
{

    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(parameter is string operation))
        {
            throw new ArgumentException("Invalid operator type", nameof(parameter));
        }

        if (values.Length != 2)
        {
            throw new ArgumentException("The number of values must be equal to two", nameof(values));
        }

        if (values[0] == DependencyProperty.UnsetValue ||
            values[1] == DependencyProperty.UnsetValue)
        {
            return DependencyProperty.UnsetValue;
        }


        var leftOperand = (dynamic)values[0];
        var rightOperand = (dynamic)values[1];

        return operation switch
        {
            "||" => leftOperand || rightOperand,
            "&&" => leftOperand && rightOperand,
            _ => throw new ArgumentException("Invalid operation", nameof(operation))
        };
    }
}

public class SingleLogicalConverter : ConverterBase
{

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(parameter is string operation))
        {
            throw new ArgumentException("Invalid operator type", nameof(parameter));
        }

        if (value == DependencyProperty.UnsetValue)
        {
            return DependencyProperty.UnsetValue;
        }


        var operand = (dynamic)value;

        if (operation == "!")
            return !operand;
        
        throw new ArgumentException("Invalid operation", nameof(operation));
    }
}