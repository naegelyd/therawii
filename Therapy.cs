using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TheraWii
{
    public class Therapy : IComparable
    {
        public string Name;
        public RepeatTask tasks;

        public Therapy()
        {
            Name = "Unnamed Therapy";

			//Creating root repeat task
            tasks = new RepeatTask();
			tasks.Name = "root";
			tasks.numRepeats = 1;
			tasks.RepeatEndType = RepeatEndType.Repetitions;
			tasks.endCondition = new Repeat_rEndCondition();
			((Repeat_rEndCondition)tasks.endCondition).Initialize(1);
        }

		public Therapy(Therapy t)
		{
			Name = "copy of " + t.Name;
			tasks = (RepeatTask)t.tasks.returnNew();
		}

        public override string ToString()
        {
            return Name;
        }

        internal TreeNode[] GetTaskTreeNodes()
        {
            TreeNode[] nodes = new TreeNode[tasks.Count];
            for (int i = 0; i < tasks.Count; i++)
            {
                nodes[i] = tasks[i].GetTreeNode();
            }
            return nodes;
        }

        internal void removeTask(Task t)
        {
			tasks.removeTask(t);
        }

        internal void addTask(Task t)
        {
			tasks.addTask(t);
        }

        public List<int> MoveUp(List<int> path)
        {
			// path is a list of ints representing the node's position in the treelist
			// the list is in reverse order - path[0] is the deepest index, path[count-1] the top index
			// return the new path to the node so caller can reselect it

			Task selTask = this.tasks;
			RepeatTask parTask = this.tasks;
			RepeatTask grandParTask = this.tasks;
			for (int i = path.Count - 1; i > -1; --i)
			{
				if (i == 1)
					parTask = (RepeatTask)((RepeatTask)selTask).tasks[path[i]];
				else if (i == 2)
					grandParTask = (RepeatTask)((RepeatTask)selTask).tasks[path[i]];

				selTask = ((RepeatTask)selTask).tasks[path[i]];
			}
		    if (path[0] == 0)  //maybe moving up
			{
				//already at the top of the root
				if (parTask == this.tasks)
			        return path;
				//move up a level
			    else
			    {
					parTask.tasks.Remove(selTask);
					path.RemoveAt(0);
					grandParTask.tasks.Insert( grandParTask.tasks.IndexOf(parTask), selTask);
					path[0] = grandParTask.tasks.IndexOf(selTask);
					return path;
			    }
			}
			else  
			{
				Task m = parTask[path[0] - 1];
				//move up into repeat task before selTask and add chain to path
				if (m.GetType() == typeof(RepeatTask))
				{
					parTask.tasks.Remove(selTask);
					((RepeatTask)m).tasks.Add(selTask);
					path[0] = path[0] - 1;
					path.Insert(0, ((RepeatTask)m).tasks.Count-1);
				}
				//swap position with task before selTask
				else
				{
					parTask[path[0] - 1] = selTask;
					parTask[path[0]] = m;
					path[0] = path[0] - 1;
				}
				return path;
			}
        }

        public List<int> MoveDown(List<int> path)
        {
			// path is a list of ints representing the node's position in the treelist
			// the list is in reverse order - path[0] is the deepest index, path[count-1] the top index
			// return the new path to the node so caller can reselect it

			Task selTask = this.tasks;
			RepeatTask parTask = this.tasks;
			RepeatTask grandParTask = this.tasks;
			for (int i = path.Count - 1; i > -1; --i)
			{
				if (i == 1)
					parTask = (RepeatTask)((RepeatTask)selTask).tasks[path[i]];
				else if (i == 2)
					grandParTask = (RepeatTask)((RepeatTask)selTask).tasks[path[i]];

				selTask = ((RepeatTask)selTask).tasks[path[i]];
			}
			if (path[0] == parTask.tasks.Count - 1)  //maybe moving down
			{
				//already at the bottom of the root
				if (parTask == this.tasks)
					return path;
				//move out of parent and below parent
				else
				{
					parTask.tasks.Remove(selTask);
					if (grandParTask.tasks.IndexOf(parTask) == grandParTask.tasks.Count - 1)
						grandParTask.tasks.Add(selTask);
					else
						grandParTask.tasks.Insert(grandParTask.tasks.IndexOf(parTask) + 1, selTask);
					
					path.RemoveAt(0);
					path[0] = grandParTask.tasks.IndexOf(selTask);
					return path;
				}
			}
			else  
			{
				Task m = parTask[path[0] + 1];
				//move down into repeat task after selTask and add chain to path
				if (m.GetType() == typeof(RepeatTask))
				{
					parTask.tasks.Remove(selTask);
					((RepeatTask)m).tasks.Insert(0, selTask);
					path.Insert(0, 0);
				}
				//swap position with task after selTask
				else
				{
					parTask[path[0] + 1] = selTask;
					parTask[path[0]] = m;
					path[0] = path[0] + 1;
				}
				return path;
			}
        }

        internal List<WiiType> getRequiredDevices()
        {
            List<WiiType> wtl = new List<WiiType>();
            if (tasks.Count > 0)
            {
                foreach (Task t in tasks.tasks)
                {
                    List<WiiType> wtl2;
                    if ((wtl2 = t.getRequiredDevices()).Count > 0)
                    {
                        foreach (WiiType wt in wtl2)
                        {
                            if (!wtl.Contains(wt))
                                wtl.Add(wt);
                        }
                    }
                }
            }
            return wtl;
        }

        public int CompareTo(Object o)
        {
            Therapy t = (Therapy)o;
            if (this.Name.CompareTo(t.Name) < 0)
                return -1;
            else
                return 1;
        }
    }
}

