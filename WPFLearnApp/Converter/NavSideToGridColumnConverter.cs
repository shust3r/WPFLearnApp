using System.Globalization;
using System.Windows.Data;
using WPFLearnApp.ViewModel;

namespace WPFLearnApp.Converter;

public class NavSideToGridColumnConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var navSide = (NavigationSide)value;
        return navSide == NavigationSide.Left
            ? 0   //value for Grid.Column
            : 2;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
