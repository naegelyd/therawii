using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheraWii
{
    [XmlInclude(typeof(DialogTask)), XmlInclude(typeof(RepeatTask)),
     XmlInclude(typeof(Task2D)), XmlInclude(typeof(Task3D))]
    public abstract class Task
    {
        //private string name;
		protected bool conditionMet;
		protected DScsv output;
		public EndCondition endCondition;
        public string Name;
        public int totalReps, currRep;

        [XmlIgnore]
        public Vector3 Position = Vector3.Zero;

		public abstract void Draw(GameTime gt);
        public abstract List<WiiType> getRequiredDevices();

		public Task returnNew()
		{
			if (this.GetType() == typeof(DialogTask))
				return new DialogTask((DialogTask)this);
			else if (this.GetType() == typeof(RepeatTask))
				return new RepeatTask((RepeatTask)this);
			else if (this.GetType() == typeof(Task2D))
				return new Task2D((Task2D)this);
			else if (this.GetType() == typeof(Task3D))
				return new Task3D((Task3D)this);
			else
				return null;
		}



        public virtual void Initialize(
            GraphicsDeviceManager g, ContentManager c, SpriteBatch sb, 
            int screenHeight, int screenWidth,
            Session s, Vector3 position)
        {
            conditionMet = false;
            endCondition.isNewExecution = true;
            Position = position;
            output = s.GetCSV();
            output.startTask(this);
        }

        public virtual void Finish()
        {
        }

		public virtual bool isComplete()
        {
            return conditionMet;
        }

		public virtual void Update(GameTime gt)
		{
			if (!conditionMet)
				conditionMet = endCondition.isMet(gt, new Region(), new Vector3());
		}

        public override string ToString()
        {
            return Name;
        }

        public virtual TreeNode GetTreeNode()
        {
            TreeNode n = new TreeNode(this.ToString());
            n.Tag = this;
            return n;
        }

        public virtual Form GetTaskForm()
        {
            return new Form();
        }
    }
}