using System;
using System.Collections.Generic;
using System.Text;

namespace TheraWii
{
    public enum SpecifierLabel { Static, Dynamic, Random };
    public class RegionParameter
    {
		
        public SpecifierLabel SL_pos;
        public SpecifierLabel SL_size;
        public float[] pos;
        public float[] size;
        public float cPos;
        public float cSize;

		public SpecifierLabel sLabel;

        public RegionParameter()
        {
            pos = new float[2];
            size = new float[2];
        }

		public RegionParameter(RegionParameter rp)
		{
			SL_pos = rp.SL_pos;
			SL_size = rp.SL_size;
			pos = new float[rp.pos.Length];
			size = new float[rp.size.Length];
			rp.pos.CopyTo(pos, 0);
			rp.size.CopyTo(size, 0);
			cPos = rp.cPos;
			cSize = rp.cSize;
			sLabel = rp.sLabel;
		}
    }
}
