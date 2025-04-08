using Infragistics.Controls.Charts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KB15838_WpfApp1;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool _isMouseLeftButtonDown = false;    // マウス左ボタンが押されている間だけ true になる変数

    public MainWindow()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        var vm = (MainWindowViewModel)DataContext;
        vm.SelectionRangeStart = null;
        vm.SelectionRangeEnd = null;
    }

    private void xamDataChart1_PlotAreaMouseLeftButtonDown(object sender, Infragistics.Controls.Charts.PlotAreaMouseButtonEventArgs e)
    {
        var x = xAxis.UnscaleValue(e.PlotAreaPosition.X);
        var y = yAxis.UnscaleValue(e.PlotAreaPosition.Y);
        var vm = (MainWindowViewModel)DataContext;
        vm.SelectionRangeStart = new Model.DataPoint(x, y);
        vm.SelectionRangeEnd = new Model.DataPoint(x, y);

        _isMouseLeftButtonDown = true;
    }

    private void xamDataChart1_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (_isMouseLeftButtonDown)
        {
            var crosshairPoint = xamDataChart1.CrosshairPoint;
            var x = (xAxis.ActualMaximumValue - xAxis.ActualMinimumValue) * crosshairPoint.X + xAxis.ActualMinimumValue;
            var vm = (MainWindowViewModel)DataContext;
            if(vm.SelectionRangeEnd != null)
            {
                vm.SelectionRangeEnd = new Model.DataPoint(x, vm.SelectionRangeEnd.Y);
            }
        }
    }

    private void xamDataChart1_PlotAreaMouseLeave(object sender, Infragistics.Controls.Charts.PlotAreaMouseEventArgs e)
    {
        if (_isMouseLeftButtonDown)
        {
            var x = xAxis.UnscaleValue(e.PlotAreaPosition.X);
            var vm = (MainWindowViewModel)DataContext;
            if (vm.SelectionRangeEnd != null)
            {
                vm.SelectionRangeEnd = new Model.DataPoint(x, vm.SelectionRangeEnd.Y);
            }
        }

        _isMouseLeftButtonDown = false;
    }

    private void xamDataChart1_PlotAreaMouseLeftButtonUp(object sender, Infragistics.Controls.Charts.PlotAreaMouseButtonEventArgs e)
    {
        _isMouseLeftButtonDown = false;
    }
}
