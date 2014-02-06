using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

namespace TheraWii
{
    public enum RepeatEndType { Repetitions, TimeLimit, Both }
    [XmlInclude(typeof(Task2D)), XmlInclude(typeof(Task3D)), XmlInclude(typeof(DialogTask))]
    public class RepeatTask : Task
    {
        public List<Task> tasks;
        public RepeatEndType RepeatEndType = RepeatEndType.Repetitions;
        public int TimeLimit, numRepeats, currTask, iterRepeat;
        private GraphicsDeviceManager g;
        private ContentManager c;
        private SpriteBatch sb;
		private int screenHeight, screenWidth;
        private Session s;
        private GameTime gt;

		public Task this[int index]
		{
			get { return tasks[index]; }
			set { tasks[index] = value; }
		}

        public override void Initialize(
            GraphicsDeviceManager g, ContentManager c, SpriteBatch sb,
            int screenHeight, int screenWidth, Session s, Vector3 position)
		{
            this.g = g;
            this.c = c;
            this.sb = sb;
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.s = s;
			currTask = 0; currRep = 0; iterRepeat = 0;
            foreach (Task t in tasks)
            {
                t.totalReps = this.numRepeats;
                t.currRep = 0;
            }
            if (tasks.Count > 0)
                tasks[0].Initialize(g, c, sb, screenHeight, screenWidth, s, position);
			conditionMet = false;
			endCondition.isNewExecution = true;
            Position = position;
		}
        
        public RepeatTask()
        {
            tasks = new List<Task>();
			numRepeats = 5;
	        TimeLimit = 30;
        }

		public RepeatTask(RepeatTask rt)
		{
			Name = rt.Name;
			numRepeats = rt.numRepeats;
			TimeLimit = rt.TimeLimit;
			RepeatEndType = rt.RepeatEndType;
			endCondition = rt.endCondition.returnNew();
			tasks = new List<Task>();
			for (int i = 0; i < rt.tasks.Count; i++)
				tasks.Add(rt.tasks[i]);
		}

		public int Count
		{
			get
			{
				return tasks.Count;
			}
		}

		public override void Draw(GameTime gt)
		{
            tasks[currTask].Draw(gt);
		}

        public override void Update(GameTime gt)
        {
            this.gt = gt;
            // current rep of current task not complete, continue executing
            if (!(tasks[currTask]).isComplete())
            {
                tasks[currTask].Update(gt);
                Position = tasks[currTask].Position;
            }
            else
            {
                Vector3 lastPosition = tasks[currTask].Position;
                tasks[currTask].Finish();

                if (currTask >= tasks.Count-1)
                {
                    ++iterRepeat;
                }

                if (iterRepeat < numRepeats)
                {
                    currTask = (currTask + 1) % tasks.Count;
                    tasks[currTask].currRep = iterRepeat;
                    tasks[currTask].Initialize(g, c, sb, screenHeight, screenWidth, s, lastPosition);
                }

            }
        }

        public override void Finish()
        {
            if (iterRepeat < numRepeats)
            {
                tasks[currTask].Finish();
            }
        }

        public override List<WiiType> getRequiredDevices()
        {
            List<WiiType> wtl = new List<WiiType>();
            if (tasks.Count > 0)
            {
                foreach (Task t in tasks)
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

        public override string ToString()
        {
            return base.ToString() + " (Repeat)";
        }

        public override TreeNode GetTreeNode()
        {
			TreeNode n = new TreeNode(this.ToString());
			n.Tag = this;
            for (int i = 0; i < tasks.Count; i++)
            {
                n.Nodes.Add(tasks[i].GetTreeNode());
            }
            return n;
        }

        public void addTask(Task t)
        {
            this.tasks.Add(t);
        }

        public void removeTask(Task t)
        {
            this.tasks.Remove(t);
        }

        public override Form GetTaskForm()
        {
            return new FormRepeatTask(this);
        }

        public override bool isComplete()
        {
			if (endCondition.GetType() == typeof(Repeat_rEndCondition))
				return conditionMet = ((Repeat_rEndCondition)endCondition).isMet(iterRepeat);
			else if (endCondition.GetType() == typeof(Repeat_tEndCondition))
				return conditionMet = ((Repeat_tEndCondition)endCondition).isMet(this.gt);
			else if (endCondition.GetType() == typeof(Repeat_BothEndCondition))
				return conditionMet = ((Repeat_BothEndCondition)endCondition).isMet(iterRepeat, this.gt);
			else return false;
        }
    }
}