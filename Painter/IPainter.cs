using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    interface IPainter
    {
       bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        decimal EstimateCost(double sqMeters);
    }    
}
