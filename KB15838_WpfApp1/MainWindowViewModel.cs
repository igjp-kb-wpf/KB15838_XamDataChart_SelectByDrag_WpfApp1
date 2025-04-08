using KB15838_WpfApp1.Infrastructure;
using KB15838_WpfApp1.Model;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace KB15838_WpfApp1;
internal class MainWindowViewModel : ObservableObject
{
    public List<DataPoint> DataPoints { get; set; } // チャートに表示するデータ本体

    private DataPoint? _selectionRangeStart;
    public DataPoint? SelectionRangeStart
    {
        get => _selectionRangeStart;
        set
        {
            _selectionRangeStart = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectionRangeMiddle));

            if (_selectionRangeStart == null || _selectionRangeEnd == null)
            {
                _selectedDataPoints = new();
            }
            else
            {
                var x0 = Math.Min(_selectionRangeStart.X, _selectionRangeEnd.X);
                var x1 = Math.Max(_selectionRangeStart.X, _selectionRangeEnd.X);
                _selectedDataPoints = DataPoints.Where(dataPoint => x0 <= dataPoint.X && dataPoint.X <= x1).ToList();
            }
            OnPropertyChanged(nameof(SelectedDataPoints));
        }
    }

    private DataPoint? _selectionRangeEnd;
    public DataPoint? SelectionRangeEnd
    {
        get => _selectionRangeEnd;
        set
        {
            _selectionRangeEnd = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectionRangeMiddle));

            if (_selectionRangeStart == null || _selectionRangeEnd == null)
            {
                _selectedDataPoints = new();
            }
            else
            {
                var x0 = Math.Min(_selectionRangeStart.X, _selectionRangeEnd.X);
                var x1 = Math.Max(_selectionRangeStart.X, _selectionRangeEnd.X);
                _selectedDataPoints = DataPoints.Where(dataPoint => x0 <= dataPoint.X && dataPoint.X <= x1).ToList();
            }
            OnPropertyChanged(nameof(SelectedDataPoints));
        }
    }

    public DataPoint? SelectionRangeMiddle
    {
        get
        {
            if (_selectionRangeStart == null || _selectionRangeEnd == null) return null;
            else
            {
                return new ()
                {
                    X = (_selectionRangeStart.X + _selectionRangeEnd.X) / 2.0,
                    Y = (_selectionRangeStart.Y + _selectionRangeEnd.Y) / 2.0,
                };
            }
        }
    }

    private List<DataPoint> _selectedDataPoints;
    public List<DataPoint> SelectedDataPoints
    {
        get => _selectedDataPoints;
        set
        {
            _selectedDataPoints = value;
            OnPropertyChanged(nameof(SelectedDataPoints));
        }
    }

    public MainWindowViewModel()
    {
        DataPoints = new ()
        {
            new () { X = 0, Y = 55 },
            new () { X = 1, Y = 49 },
            new () { X = 2, Y = 39 },
            new () { X = 3, Y = 35 },
            new () { X = 4, Y = 25 },
            new () { X = 5, Y = 18 },
            new () { X = 6, Y = 21 },
            new () { X = 7, Y = 29 },
            new () { X = 8, Y = 37 },
            new () { X = 9, Y = 36 }
        };

        _selectedDataPoints = new List<DataPoint>();
    }
}