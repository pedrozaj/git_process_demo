using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace A35WPFSample.Converters
{
    public class BoolToValueConverter<T> : IValueConverter
    {
        public T FalseValue { get; set; }
        public T TrueValue { get; set; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return FalseValue;
            }
            else
            {
                if (parameter != null)
                {
                    if (parameter.ToString() == "int")
                        return (int)value > 0 ? TrueValue : FalseValue;
                    else if (parameter.ToString() == "minCount2")
                        return (int)value > 1 ? TrueValue : FalseValue;
                    else if (parameter.ToString() == "minCount3")
                        return (int)value > 2 ? TrueValue : FalseValue;
                    else
                        return (bool)value ? TrueValue : FalseValue;
                }
                else
                    return (bool)value ? TrueValue : FalseValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(TrueValue);
        }
    }

    public class BoolToVisibilityConverter : BoolToValueConverter<Visibility> { }
    public class BoolToInverseConverter : BoolToValueConverter<bool> { }
    public class IntToSizeConverter : BoolToValueConverter<double> { }
    public class IntToVisibilityConverter : BoolToValueConverter<Visibility> { }
}
