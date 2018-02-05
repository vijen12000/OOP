using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    class CheapestPainter
    {

        public static IPainter FindCheapestPrinter_v2(double sqMeters, IEnumerable<IPainter> painters)
        {
            //Worst Implemenation
            return
                painters
                .Where(w=>w.IsAvailable)
                .OrderBy(p=>p.EstimateCost(sqMeters))
                .FirstOrDefault();
        }
        public static IPainter FindCheapestPrinter_v1(double sqMeters,IEnumerable<IPainter> painters)
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
