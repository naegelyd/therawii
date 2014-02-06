using System;
using System.Xml.Serialization;

namespace TheraWii
{
    public class Task3D : DimensionalTask
    {
        public Task3D()
        {
            endCondition = new ButtonEndCondition();
            primaryInput = new InputBalanceBoard();
            region = new Region();
            inputHandling = InputHandling.Differential;
        }

		public Task3D(Task3D t)
		{
			throw new NotImplementedException();
		}

        public override string ToString()
        {
            return base.ToString() + " (3D Task)";
        }

        public override System.Windows.Forms.Form GetTaskForm()
        {
            return new Form3DTask(this);
        }
    }
}
