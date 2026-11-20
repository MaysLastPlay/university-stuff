using System.Globalization;
using System.Windows.Data;

namespace WpfLab9.classes.services
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int age)
                return value;

            int lastTwo = age % 100;
            int lastOne = age % 10;

            string suffix = (lastTwo >= 11 && lastTwo <= 14) ? "років"
                : lastOne == 1 ? "рік"
                : (lastOne >= 2 && lastOne <= 4) ? "роки"
                : "років";

            return $"{age} {suffix}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}