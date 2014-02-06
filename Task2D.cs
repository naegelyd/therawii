using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace TheraWii
{
    public class Task2D : DimensionalTask
    {
        /* create both of these since we don't know what type of region, if any, we will need to draw */
        private Cuboid rectangle;
        private Ellipsoid ellipse;
        private Hoop hoop;
        private Random rand;

        private SoundEffect swish;

        public Task2D()
        {
			additionalInput = new List<InputDevice>();
            endCondition = new ButtonEndCondition();
            primaryInput = new InputBalanceBoard();
			regionEnabled = false;
            rand = new Random();
            region = new Region();
			((RegionParameter)region.rParams[regPT.Z]).pos = new float[2]{0,0};
			((RegionParameter)region.rParams[regPT.Z]).size = new float[2]{0,0};
        }

		public Task2D(Task2D tk)
		{
			Name = "copy of " + tk.Name;
			additionalInput = new List<InputDevice>(tk.additionalInput);
			endCondition = tk.endCondition.returnNew();
			primaryInput = tk.primaryInput.returnNew();
			regionEnabled = tk.regionEnabled;
            rand = new Random();
			region = new Region(tk.region);
			}


        public override void Initialize(
            GraphicsDeviceManager g, ContentManager c, SpriteBatch sb,
            int screenHeight, int screenWidth, Session s, Vector3 position)
        {
            base.Initialize(g, c, sb, screenHeight, screenWidth, s, position);
            // determine shape size position on parameter type and repetition.
            int l, h;
            foreach (RegionParameter r in region.rParams.Values)
            {
                // update current position x,y,z
                if (r.SL_pos == SpecifierLabel.Static)
                    r.cPos = r.pos[1];
                else if (r.SL_pos == SpecifierLabel.Random)
                {
                    l = (int)((r.pos[0] + 1) * 100);
                    h = (int)((r.pos[1] + 1) * 100);
                    r.cPos = ((float)rand.Next(l, h) / 100) - 1;
                }
                else if (r.SL_pos == SpecifierLabel.Dynamic)
                {
                    if (currRep == 0)
                        r.cPos = r.pos[0];
                    else if (currRep < totalReps)
                        r.cPos += (r.pos[1] - r.pos[0])/(totalReps-1);
                }
                // update current size x,y,z
                if (r.SL_size == SpecifierLabel.Static)
                    r.cSize = r.size[1];
                else if (r.SL_size == SpecifierLabel.Random)
                {
                    l = (int)((r.size[0]) * 100);
                    h = (int)((r.size[1]) * 100);
                    r.cSize = ((float)rand.Next(l, h) / 100);
                }
                else if (r.SL_size == SpecifierLabel.Dynamic)
                {
                    if (currRep == 0)
                        r.cSize = r.size[0];
                    else if (currRep < totalReps)
                        r.cSize += (r.size[1] - r.size[0]) / (totalReps-1);
                }
                // make sure no region is partially outside the coordinate system
				if (region.Shape == ShapeType.Rectangle)
				{
					if (r.cPos - r.cSize / 2 < -1)
						r.cPos += (-1 - (r.cPos - r.cSize / 2));
					else if (r.cPos + r.cSize / 2 > 1)
						r.cPos -= (-1 + (r.cPos + r.cSize / 2));
				}
                this.swish = c.Load<SoundEffect>("Sounds\\bbswish");
            }

            if (region.Shape == ShapeType.Rectangle)
            {
                rectangle = new Cuboid(g,
                                       c,
                                       new Vector3(((RegionParameter)region.rParams[regPT.X]).cPos, ((RegionParameter)region.rParams[regPT.Y]).cPos, 0.0f),
                                       new Vector3(((RegionParameter)region.rParams[regPT.X]).cSize, ((RegionParameter)region.rParams[regPT.Y]).cSize, 0.0f),
                                       Color.DarkBlue);
            }
            else if (region.Shape == ShapeType.Ellipse)
            {
                ellipse = new Ellipsoid(g,
                                        c,
                                       new Vector3(((RegionParameter)region.rParams[regPT.X]).cPos, ((RegionParameter)region.rParams[regPT.Y]).cPos, 0.0f),
                                       new Vector3(((RegionParameter)region.rParams[regPT.X]).cSize/2, ((RegionParameter)region.rParams[regPT.Y]).cSize/2, 0.0f), 
                                       Color.DarkBlue);
            }
            else if (region.Shape == ShapeType.Hoop)
            {
                hoop = new Hoop(g,
                                c,
                                new Vector3(((RegionParameter)region.rParams[regPT.X]).cPos, ((RegionParameter)region.rParams[regPT.Y]).cPos, 0.0f),
                                new Vector3(((RegionParameter)region.rParams[regPT.X]).cSize, ((RegionParameter)region.rParams[regPT.Y]).cSize, 0.0f),
                                Color.DarkBlue);
            }
        }

        public override void Finish()
        {
            base.Finish();
            if (region.Shape == ShapeType.Hoop)
            {
                swish.Play();
            }
        }

        public override void Draw(GameTime gt)
        {
            if (regionEnabled)
            {
                if (region.Shape == ShapeType.Rectangle)
                {
                    rectangle.Draw();
                }
                else if (region.Shape == ShapeType.Ellipse)
                {
                    ellipse.Draw();
                }
                else if (region.Shape == ShapeType.Hoop)
                {
                    hoop.Draw();
                }
            }

            // Draw cursor last
            base.Draw(gt);
        }

        public override string ToString()
        {
            return base.ToString() + " (2D Task)";
        }

        public override System.Windows.Forms.Form GetTaskForm()
        {
            return new Form2DTask(this);
        }
    }
}
