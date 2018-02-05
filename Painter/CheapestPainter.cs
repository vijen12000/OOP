using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    class CheapestPainter
    {
        public static IPainter FindCheapestPrinter(double sqMeters,IEnumerable<IPainter> painters)
        {
            decimal bestPrice = 0;
            IPainter cheapest = null;
            //for each painter
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    var price = painter.EstimateCost(sqMeters);
                    if (cheapest ==null || bestPrice < price)
                    {
                        cheapest = painter;
                    }
                }
            }
            return cheapest;
        }
    }
}
