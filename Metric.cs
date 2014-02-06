using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TheraWii
{
    [XmlInclude(typeof(TimeInRegion)), XmlInclude(typeof(TimeOutRegion)),
    XmlInclude(typeof(TotalTime)), XmlInclude(typeof(CenterOfBalanceAverage)),
    XmlInclude(typeof(CenterOfBalancePosition)), XmlInclude(typeof(Smoothness))]
    public abstract class Metric
    {
        public static Metric[] GetPossibleMetrics()
        {
            return new Metric[] {
                new TimeInRegion(),
                new TimeOutRegion(),
                new TotalTime(),
                new CenterOfBalanceAverage(),
                new CenterOfBalancePosition(),
                new Smoothness()
            };
        }

        public static int GetMetricIndex(Metric m)
        {
            if (m.GetType() == typeof(TimeInRegion))
                return 0;
            else if (m.GetType() == typeof(TimeOutRegion))
                return 1;
            else if (m.GetType() == typeof(TotalTime))
                return 2;
            else if (m.GetType() == typeof(CenterOfBalanceAverage))
                return 3;
            else if (m.GetType() == typeof(CenterOfBalancePosition))
                return 4;
            else if (m.GetType() == typeof(Smoothness))
                return 5;
            return 0;
        }
    }

    public class TimeInRegion : Metric
    {
        public override string ToString()
        {
            return "Time In Region";
        }
    }

    public class TimeOutRegion : Metric
    {
        public override string ToString()
        {
            return "Time Out Region";
        }
    }

    public class TotalTime : Metric
    {
        public override string  ToString()
        {
 	        return "Center of Balance Position";
        }
    }

    public class CenterOfBalanceAverage : Metric
    {
        public override string ToString()
        {
            return "Center of Balance Average";
        }
    }

    public class CenterOfBalancePosition : Metric
    {
        public override string ToString()
        {
 	         return "Center of Balance Position";
        }
    }

    public class Smoothness : Metric
    {
        public override string ToString()
        {
            return "Smoothness";
        }
    }
}
