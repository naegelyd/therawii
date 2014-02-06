using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheraWii
{
    class NunchuckState : WiiControllerState
    {
        public ButtonState c;
        public ButtonState z;
        public float joyAngle;
        public float joyMagnitude;
        public float roll;
        public float pitch;
        public Vector3 accel;

        public NunchuckState()
        {
            accel = Vector3.Zero;
        }
        public void Initialize()
        {
            c = ButtonState.Released;
            z = ButtonState.Released;
            joyAngle = 0;
            joyMagnitude = 0;
            connected = false;
        }

        public Boolean connected;
        public Boolean isConnected()
        {
            return connected;
        }

        internal NunchuckState Copy()
        {
            return (NunchuckState)this.MemberwiseClone();
        }
    }
}
