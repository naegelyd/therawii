using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace TheraWii
{
    public enum ShapeType { Rectangle, Ellipse, Cuboid, Ellipsoid, Hoop, NONE };
    public enum regPT { X, Y, Z };
	
    public class Region
    {
		public ShapeType Shape = ShapeType.NONE;
        public bool regionEnabled;
        public SerializableDictionary<regPT, RegionParameter> rParams;

        public Region()
        {
            rParams = new SerializableDictionary<regPT,RegionParameter>();
            rParams.Add(regPT.X, new RegionParameter());
            rParams.Add(regPT.Y, new RegionParameter());
            rParams.Add(regPT.Z, new RegionParameter());
            
            regionEnabled = false;
        }

		public Region(Region r)
		{
			regionEnabled = r.regionEnabled;
			rParams = new SerializableDictionary<regPT, RegionParameter>();
			foreach (regPT rPT in r.rParams.Keys)
			{
				rParams.Add(rPT, new RegionParameter(r.rParams[rPT]));
			}
			Shape = r.Shape;
		}

		public override string ToString()
		{
			return "x_pos: " + rParams[regPT.X].cPos.ToString() + "   y_pos: " +
                rParams[regPT.Y].cPos.ToString() + "    z_pos: " +
                rParams[regPT.Z].cPos.ToString() + "   x_size: " +
                rParams[regPT.X].cSize.ToString() + "    y_size:  " +
                rParams[regPT.Y].cSize.ToString() + "    z_size: " +
                rParams[regPT.Z].cSize.ToString();
		}

        public bool isInRegion(Vector3 pos)
        {
            switch (Shape)
            {
                case ShapeType.Rectangle:
                case ShapeType.Hoop:
                    return isIn2DRect(pos);

                case ShapeType.Ellipse:
                    return isIn2DEllipse(pos);

                default:
                    return false;
            }
        }

        public bool isIn2DRect(Vector3 pos)
        {
            float halfWidth = rParams[regPT.X].cSize / 2;
            float halfHeight = rParams[regPT.Y].cSize / 2;
            float minX = rParams[regPT.X].cPos - halfWidth;
            float maxX = rParams[regPT.X].cPos + halfWidth;
            float minY = rParams[regPT.Y].cPos - halfHeight;
            float maxY = rParams[regPT.Y].cPos + halfHeight;

            if (minX <= pos.X && pos.X <= maxX &&
                minY <= pos.Y && pos.Y <= maxY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isIn2DEllipse(Vector3 pos)
        {
            double twoA = 0;
            double eccentricity;
            Vector3 center = new Vector3(rParams[regPT.X].cPos, rParams[regPT.Y].cPos, rParams[regPT.Z].cPos);
            Vector3 c1, c2;
            if (rParams[regPT.X].cSize >= rParams[regPT.Y].cSize)
            {
                twoA = rParams[regPT.X].cSize;
                eccentricity = Math.Sqrt(1 - Math.Pow(rParams[regPT.Y].cSize / rParams[regPT.X].cSize, 2));
                float offset = (float)(eccentricity * twoA / 2);
                c1 = new Vector3(center.X - offset, center.Y, center.Z);
                c2 = new Vector3(center.X + offset, center.Y, center.Z);
            }
            else
            {
                twoA = rParams[regPT.Y].cSize;
                eccentricity = Math.Sqrt(1 - Math.Pow(rParams[regPT.X].cSize / rParams[regPT.Y].cSize, 2));
                float offset = (float)(eccentricity * twoA / 2);
                c1 = new Vector3(center.X, center.Y - offset, center.Z);
                c2 = new Vector3(center.X, center.Y + offset, center.Z);
            }
            double d1, d2;
            d1 = Math.Sqrt(Math.Pow(c1.X - pos.X, 2) + Math.Pow(c1.Y - pos.Y, 2));
            d2 = Math.Sqrt(Math.Pow(c2.X - pos.X, 2) + Math.Pow(c2.Y - pos.Y, 2));

            return (d1 + d2) < twoA;
        }
    }
}
