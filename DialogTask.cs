using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheraWii
{
    
    public class DialogTask : Task
    {
        private string displayText;
        [XmlIgnore]
        public GameTextBox textBox;

        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

        public DialogTask()
        {
            endCondition = new ButtonEndCondition();
        }

		public DialogTask(DialogTask d)
		{
			Name = "copy of" + d.Name;
			displayText = d.displayText;
			endCondition = d.endCondition.returnNew();
		}

        public override List<WiiType> getRequiredDevices()
        {
            List<WiiType> wt = endCondition.getRequiredDevices();  
            return wt;                
        }

        public override void Initialize(
            GraphicsDeviceManager g, ContentManager c, SpriteBatch sb,
            int screenHeight, int screenWidth, Session s, Vector3 position)
        {
            base.Initialize(g, c, sb, screenHeight, screenWidth, s, position);

            textBox = new GameTextBox();
            String buttonText = "";
            /* create some space in the text message before printing the end condition critera */
            if (endCondition.GetType() == typeof(ButtonEndCondition))
            {
                buttonText = "\n\nHit the " + ((ButtonEndCondition)endCondition).getButtonText() + " to continue.";
            }
            else if (endCondition.GetType() == typeof(TimeLimitEndCondition))
            {
                buttonText = "\n\n\nTherapy will continue in " + ((TimeLimitEndCondition)endCondition).TimeLimit + " seconds.";
            }
            
            textBox.Initialize(displayText + buttonText, c, sb, screenHeight, screenWidth);
        }
       
        public override void Draw(GameTime gt)
        {
            textBox.Draw();
        }

        public override string ToString()
        {
            return base.ToString() + " (Dialog)";
        }

        public override System.Windows.Forms.Form GetTaskForm()
        {
            return new FormDialogTask(this);
        }
    }
}

