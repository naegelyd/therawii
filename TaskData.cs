using System;

namespace TheraWii
{
    public class TaskData
    {

        public String TaskName;
        public PerformanceMetrics Metrics;

        public TaskData()
        {
            Metrics = new PerformanceMetrics();
        }

    }
}

