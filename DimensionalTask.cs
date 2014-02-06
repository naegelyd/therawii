using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TheraWii
{
    public abstract class DimensionalTask : Task
    {
        public Region region;

        public InputDevice primaryInput;
        public InputHandling inputHandling;
        public List<InputDevice> additionalInput;
        public PerformanceMetricType performanceMetric;

        public bool regionEnabled;

        private Ellipsoid cursor;
        private TaskData taskData;
                
		public override void Initialize(
            GraphicsDeviceManager g, ContentManager c, SpriteBatch sb,
            int screenHeight, int screenWidth, Session s, Vector3 position)
		{
            base.Initialize(g, c, sb, screenHeight, screenWidth, s, position);
			primaryInput.Initialize(Position);
            foreach (InputDevice id in additionalInput)
            {
                id.Initialize(Position);
            }

            if (region.Shape == ShapeType.Hoop)
            {
                cursor = new Basketball(g, c, Position, Vector3.One, Color.Red);
            }
            else
            {
                cursor = new Ellipsoid(g, c, Position, Vector3.One, Color.Red);
            }

            cursor.Scale = new Vector3(0.02f, 0.02f, 0.02f);

			primaryInput.writeFields(output);
            primaryInput.Handling = inputHandling;
			foreach (InputDevice ID in additionalInput)
			{
				ID.writeFields(output);
                ID.Handling = inputHandling;
			}

            taskData = new TaskData();
            taskData.TaskName = this.Name;
            taskData.Metrics.primary = (int)performanceMetric;
            s.TaskDatas.Add(taskData);

			if ((endCondition.GetType() == typeof(TimeLimitEndCondition) &&  ((TimeLimitEndCondition)endCondition).Type == TimeLimitType.TimeInRegion) ||
				(endCondition.GetType() == typeof(TimeLimitEndCondition) && ((TimeLimitEndCondition)endCondition).Type == TimeLimitType.TimeOutRegion))
				output.addField("IsInRegion");
			output.addField("RegionX1");
			output.addField("RegionX2");
			output.addField("RegionY1");
			output.addField("RegionY2");
			output.addField("RegionZ1");
			output.addField("RegionZ2");

			output.writeHeader();
		}

        public override void Finish()
        {
            primaryInput.Finish();
            taskData.Metrics.WriteOutput(output);
            base.Finish();
        }

        public override void Update(GameTime gt)
        {
            //base.Update(gt);
            Position = primaryInput.getXYZ();
            cursor.Position = Position;
            if (!conditionMet)
                conditionMet = endCondition.isMet(gt, region, cursor.Position);

			output.newRecord(gt.ElapsedGameTime);
			if ((endCondition.GetType() == typeof(TimeLimitEndCondition) && ((TimeLimitEndCondition)endCondition).Type == TimeLimitType.TimeInRegion) ||
				(endCondition.GetType() == typeof(TimeLimitEndCondition) && ((TimeLimitEndCondition)endCondition).Type == TimeLimitType.TimeOutRegion))
				output.setData("IsInRegion", ((TimeLimitEndCondition)endCondition).inRegion.ToString());
			output.setData("RegionX1", (((RegionParameter)region.rParams[regPT.X]).cPos- ((RegionParameter)region.rParams[regPT.X]).cSize / 2).ToString());
			output.setData("RegionX2", (((RegionParameter)region.rParams[regPT.X]).cPos+ ((RegionParameter)region.rParams[regPT.X]).cSize / 2).ToString());
            output.setData("RegionY1", (((RegionParameter)region.rParams[regPT.Y]).cPos - ((RegionParameter)region.rParams[regPT.Y]).cSize / 2).ToString());
            output.setData("RegionY2", (((RegionParameter)region.rParams[regPT.Y]).cPos + ((RegionParameter)region.rParams[regPT.Y]).cSize / 2).ToString());
            output.setData("RegionZ1", (((RegionParameter)region.rParams[regPT.Z]).cPos - ((RegionParameter)region.rParams[regPT.Z]).cSize / 2).ToString());
            output.setData("RegionZ2", (((RegionParameter)region.rParams[regPT.Z]).cPos + ((RegionParameter)region.rParams[regPT.Z]).cSize / 2).ToString());

			//primary input
			primaryInput.writeStatus(output);

			//write other input status
			foreach (InputDevice ID in additionalInput)
			{
				ID.writeStatus(output);
			}

			//write record
			output.writeRecord();

            taskData.Metrics.Update(gt, this);
        }

		public override void Draw(GameTime gt)
		{
            cursor.Draw();
		}

        public override List<WiiType> getRequiredDevices()
        {
            List<WiiType> wt = new List<WiiType>();
            WiiType wti;
            if (primaryInput != null)
            {
                if (!wt.Contains(wti = primaryInput.getInputEnum()))
                    wt.Add(wti);
            }
            if (additionalInput != null && additionalInput.Count > 0)
            {
                foreach (InputDevice id in additionalInput)
                    if (!wt.Contains(wti = id.getInputEnum()))
                        wt.Add(wti);
            }
            List<WiiType> wt2;
            if ((wt2 = endCondition.getRequiredDevices()).Count > 0)
            {
                foreach (WiiType wte in wt2)
                {
                    if (!wt.Contains(wte))
                        wt.Add(wte);
                }
            }
            return wt;
        }

        public bool IsInRegion()
        {
            return region.isInRegion(cursor.Position);
        }
    }
}
