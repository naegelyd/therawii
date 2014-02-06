using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace TheraWii
{
    public enum PerformanceMetricType
    {
        TotalTime = 0,
        TimeInRegion,
        TimeOutRegion,
        PathLength,
        PathDistance,
        PathEfficiency,
        MotionArea,
        LocationXAverage,
        LocationYAverage,
        LocationZAverage,
        SpeedAverage
    }

    public class PerformanceMetrics
    {
        public static string[] PerformanceMetricStrings = new string[] {
            "Total Time",
            "Time In Region",
            "Time Out of Region",
            "Path Length",
            "Path Distance",
            "Path Efficiency",
            "Motion Area",
            "Location X Average",
            "Location Y Average",
            "Location Z Average",
            "Speed Average"
        };

        private const int numMetrics = 11;

        public float[] metrics;
        public int primary;

        private Vector3 minPos, maxPos;
        private float samples;
        private Vector3 locationSum;
        private Vector3 lastPos;
        private Vector3 firstPos;
        private bool gotFirstPos = false;

        public PerformanceMetrics()
        {
            metrics = new float[numMetrics];
            for (int i = 0; i < numMetrics; i++)
            {
                metrics[i] = 0.0f;
            }
            primary = 0;
            minPos = new Vector3(0, 0, 0);
            maxPos = new Vector3(0, 0, 0);
            locationSum = new Vector3(0, 0, 0);
            lastPos = new Vector3(0, 0, 0);
            samples = 0;
        }

        public void Update(GameTime gt, DimensionalTask t)
        {
            samples++;
            Vector3 pos = t.Position;

            if (!gotFirstPos)
            {
                firstPos = pos;
                gotFirstPos = true;
            }

            // Times
            metrics[(int)PerformanceMetricType.TotalTime]
                += (float)gt.ElapsedGameTime.TotalSeconds;
            if (t.IsInRegion())
            {
                metrics[(int)PerformanceMetricType.TimeInRegion]
                    += (float)gt.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                metrics[(int)PerformanceMetricType.TimeOutRegion] 
                    += (float)gt.ElapsedGameTime.TotalSeconds;
            }

            // Path Length
            metrics[(int)PerformanceMetricType.PathLength] += (pos - lastPos).Length();

            // Path Distance
            metrics[(int)PerformanceMetricType.PathDistance] = (pos - firstPos).Length();

            // Path Efficiency
            metrics[(int)PerformanceMetricType.PathEfficiency] =
                metrics[(int)PerformanceMetricType.PathDistance] / metrics[(int)PerformanceMetricType.PathLength];

            // Motion Area
            minPos.X = Math.Min(minPos.X, t.Position.X);
            minPos.Y = Math.Min(minPos.Y, t.Position.Y);
            minPos.Z = Math.Min(minPos.Z, t.Position.Z);
            maxPos.X = Math.Max(maxPos.X, t.Position.X);
            maxPos.Y = Math.Max(maxPos.Y, t.Position.Y);
            maxPos.Z = Math.Max(maxPos.Z, t.Position.Z);
            metrics[(int)PerformanceMetricType.MotionArea] = (maxPos.X - minPos.X) * (maxPos.Y - minPos.Y);

            // Location average
            locationSum += pos;
            Vector3 locationAvg = locationSum / samples;
            metrics[(int)PerformanceMetricType.LocationXAverage] = locationAvg.X;
            metrics[(int)PerformanceMetricType.LocationYAverage] = locationAvg.Y;
            metrics[(int)PerformanceMetricType.LocationZAverage] = locationAvg.Z;

            // Speed Average
            metrics[(int)PerformanceMetricType.SpeedAverage] =
                metrics[(int)PerformanceMetricType.PathLength] / metrics[(int)PerformanceMetricType.TotalTime];

            lastPos = pos;
        }

        public void WriteOutput(DScsv output)
        {
            output.WriteLine("#Performance Metrics:");
            for (int i = 0; i < numMetrics; i++)
            {
                output.WriteLine(PerformanceMetricStrings[i] + "," + metrics[i]);
            }
        }
    }
}
