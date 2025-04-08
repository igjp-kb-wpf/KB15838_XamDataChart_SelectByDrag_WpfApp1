using KB15838_WpfApp1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB15838_WpfApp1.Model;
internal class DataPoint
{
    public double X { get; set; }
    public double Y { get; set; }

    public DataPoint()
    {
    }

    public DataPoint(double x, double y)
    {
        X = x;
        Y = y;
    }
}
