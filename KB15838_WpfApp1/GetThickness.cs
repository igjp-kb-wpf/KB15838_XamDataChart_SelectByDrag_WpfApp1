using Infragistics.Controls.Charts;
using KB15838_WpfApp1.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KB15838_WpfApp1;
internal class GetThickness : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null || values.Length != 3
            || values[0] == null || values[0].GetType() != typeof(DataPoint)
            || values[1] == null || values[1].GetType() != typeof(DataPoint)
            || values[2] == null || values[2].GetType() != typeof(NumericXAxis))
        {
            return new Thickness(0);
        }

        var start = (DataPoint)values[0];
        var end = (DataPoint)values[1];
        var xAxis = (NumericXAxis)values[2];

        var x0 = xAxis.ScaleValue(start.X);
        var x1 = xAxis.ScaleValue(end.X);
        return Math.Max(Math.Abs(x0 - x1), 1);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
