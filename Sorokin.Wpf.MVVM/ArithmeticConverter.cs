using System.Globalization;
using System.Windows;
using Sorokin.Wpf.MVVM.Core.Converter;

namespace Sorokin.Wpf.MVVM;

internal sealed class ArithmeticConverter : MultiConverterBase
{

    private bool HasMethod(object objectToCheck, string methodName)
    {
        var type = objectToCheck.GetType();
        return type.GetMethod(methodName) != null;
    }

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

        // if (HasMethod(leftOperand, "op_A"))
        //TODO:change ops names
        switch (operation)
        {
            case "+":
            {
                if (HasMethod(leftOperand, "op_Addition") &&
                    HasMethod(rightOperand, "op_Addition"))
                    return leftOperand + rightOperand;
                throw new ArgumentException(
                    "The argument type does not support the operation", nameof(leftOperand));
            }
            case "-":
            {
                if (HasMethod(leftOperand, "op_Addition") &&
                    HasMethod(rightOperand, "op_Addition"))
                    return leftOperand - rightOperand;
                throw new ArgumentException(
                    "The argument type does not support the operation", nameof(leftOperand));
            }
            case "*":
            {
                if (HasMethod(leftOperand, "op_Addition") &&
                    HasMethod(rightOperand, "op_Addition"))
                    return leftOperand * rightOperand;
                throw new ArgumentException(
                    "The argument type does not support the operation", nameof(leftOperand));
            }
            case "/":
            {
                if (HasMethod(leftOperand, "op_Addition") &&
                    HasMethod(rightOperand, "op_Addition"))
                    return leftOperand / rightOperand;
                throw new ArgumentException(
                    "The argument type does not support the operation", nameof(leftOperand));
            }
            case "%":
            {
                if (HasMethod(leftOperand, "op_Addition") &&
                    HasMethod(rightOperand, "op_Addition"))
                    return leftOperand % rightOperand;
                throw new ArgumentException(
                    "The argument type does not support the operation", nameof(leftOperand));
            }
            default: throw new ArgumentException("Invalid operation", nameof(operation));
        }

        // return operation switch
        // {
        //     "+" => leftOperand + rightOperand,
        //     "-" => leftOperand - rightOperand,
        //     "*" => leftOperand * rightOperand,
        //     "/" => leftOperand / rightOperand,
        //     "%" => leftOperand % rightOperand,
        //     _ => throw new ArgumentException("Invalid operation", nameof(operation))
        // };
    }
}