﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> predicate)
                where T : class
                where TKey : IComparable<TKey>
                => sequence.Aggregate((T)null, (best, cur) => best == null || predicate(cur).CompareTo(predicate(best))<0 ?
                    best : cur);
    }
    class CheapestPainter
    {
        /// <summary>
        /// Use of extension Method
        /// </summary>
        /// <param name="sqMeters"></param>
        /// <param name="painters"></param>
        /// <returns></returns>
        public static IPainter FindCheapestPrinter_v4(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                .Where(w => w.IsAvailable)
                .WithMinimum(p=>p.EstimateCost(sqMeters));
        }

        /// <summary>
        /// With Aggrigate but estimate function is called with each iteration twice, slightly better then v3
        /// </summary>
        /// <param name="sqMeters"></param>
        /// <param name="painters"></param>
        /// <returns></returns>
        public static IPainter FindCheapestPrinter_v3(double sqMeters, IEnumerable<IPainter> painters)
        {
            return
                painters
                .Where(w => w.IsAvailable)
                .Aggregate((IPainter)null,(best, cur) => best==null || best.EstimateCost(sqMeters) < cur.EstimateCost(sqMeters) ?
                  best : cur);
        }

        /// <summary>
        /// With Aggrigate but estimate function is called with each iteration twice, slightly better then v2, but can be improved
        /// and throws exception if sequence is empty
        /// </summary>
        /// <param name="sqMeters"></param>
        /// <param name="painters"></param>
        /// <returns></returns>
        public static IPainter FindCheapestPrinter_v3(double sqMeters, IEnumerable<IPainter> painters)
        {            
            return
                painters
                .Where(w => w.IsAvailable)
                .Aggregate((best,cur)=>best.EstimateCost(sqMeters) < cur.EstimateCost(sqMeters) ?
                  best:cur);
        }

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
