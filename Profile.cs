using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace TheraWii
{
    public class Profile : IComparable
    {
        public Profile()
        {
            Sessions = new List<Session>();
        }

        public void initialize(string name)
        {
            Name = name;
            CreateDate = DateTime.Now;
            System.IO.Directory.CreateDirectory(GetDataFolder());
        }

        public DateTime CreateDate;
        public List<Session> Sessions;
        public string Name;

        public ListViewItem getListViewItem()
        {
            ListViewItem a = new ListViewItem(Name);
            a.SubItems.Add(CreateDate.ToShortDateString());
            a.SubItems.Add(Sessions.Count.ToString());
            a.Tag = this;
            return a;
        }

        public ListView.ListViewItemCollection getSessionList(ListView owner)
        {
            ListView.ListViewItemCollection colListVItem = new ListView.ListViewItemCollection(owner);
            int i = 1;
            ListViewItem t;
            foreach (Session s in Sessions)
            {
                t = new ListViewItem(i.ToString());
                t.SubItems.AddRange(s.getSubItems());
                t.Tag = s;
                colListVItem.Add(t);
                i++;
            }
            return colListVItem;
        }

        public void deleteSession(Session s)
        {
            s.delete();
            Sessions.Remove(s);
        }

        public void delete()
        {
			try { System.IO.Directory.Delete(GetDataFolder(), true); }
			catch (System.IO.DirectoryNotFoundException) { }
        }

        public string GetDataFolder()
        {
            return Path.Combine(DataStorage.DATA_STORE_FOLDER, Name);
        }

        // Updates Profile, Session, Folder, but not CSV filenames or CSV data
        public void Rename(string newName)
        {
            string oldPath = GetDataFolder();
            Name = newName;
            System.IO.Directory.Move(oldPath, GetDataFolder());
            foreach (Session s in Sessions)
            {
                s.profile = Name;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Object o)
        {
            Profile p = (Profile)o;
            if (this.Name.CompareTo(p.Name) < 0)
                return -1;
            else
                return 1;
        }

        public string[] GetAllTherapies()
        {
            List<string> l = new List<string>();
            foreach (Session s in Sessions)
            {
                if (!l.Contains(s.therapy))
                {
                    l.Add(s.therapy);
                }
            }

            return l.ToArray();
        }

        public string[] GetAllTasks(string therapy)
        {
            List<string> l = new List<string>();
            foreach (Session s in Sessions)
            {
                if (s.therapy == therapy)
                {
                    foreach (TaskData t in s.TaskDatas)
                    {
                        if (!l.Contains(t.TaskName))
                        {
                            l.Add(t.TaskName);
                        }
                    }
                }
            }

            return l.ToArray();
        }

        public PerformanceMetricType GetPrimaryMetric(string therapy, string task)
        {
            // Use last session
            for (int i = Sessions.Count - 1; i >= 0; i--)
            {
                // That matches therapy
                if (Sessions[i].therapy == therapy)
                {
                    // Use first task
                    foreach (TaskData t in Sessions[i].TaskDatas)
                    {
                        // That matches task
                        if (t.TaskName == task)
                        {
                            return (PerformanceMetricType)t.Metrics.primary;
                        }
                    }
                }
            }
            return PerformanceMetricType.TotalTime;
        }

        public DataPoints GetMetricPoints(string therapy, string task, PerformanceMetricType metric)
        {
            List<DateTime> dates = new List<DateTime>();
            List<float> points = new List<float>();
            foreach (Session s in Sessions)
            {
                if (s.therapy == therapy)
                {
                    float sum = 0;
                    float count = 0;
                    foreach (TaskData t in s.TaskDatas)
                    {
                        if (t.TaskName == task)
                        {
                            sum += t.Metrics.metrics[(int)metric];
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        dates.Add(s.createDate);
                        points.Add(sum / count);
                    }
                }
            }
            return new DataPoints(dates.ToArray(), points.ToArray());
        }

    }

    public class DataPoints
    {
        public DateTime[] Xs;
        public float[] Ys;
        public DataPoints(DateTime[] xs, float[] ys)
        {
            Xs = xs;
            Ys = ys;
        }
    }

    

}