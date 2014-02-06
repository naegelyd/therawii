using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheraWii
{
    class WiimoteState : WiiControllerState
    {
        public ButtonState home;
        public ButtonState plus;
        public ButtonState minus;
        public ButtonState dUp;
        public ButtonState dRight;
        public ButtonState dDown;
        public ButtonState dLeft;
        public ButtonState one;
        public ButtonState two;
        public ButtonState a;
        public ButtonState b;
        public IRState ir;
        public float roll;
        public float pitch;
        public Vector3 accel;


        public WiimoteState()
        {
            ir = new IRState();
            accel = Vector3.Zero;
        }

        public void Initialize()
        {
            home = ButtonState.Released;
            plus = ButtonState.Released;
            minus = ButtonState.Released;
            dUp = ButtonState.Released;
            dRight = ButtonState.Released;
            dDown = ButtonState.Released;
            dLeft = ButtonState.Released;
            one = ButtonState.Released;
            two = ButtonState.Released;
            a = ButtonState.Released;
            b = ButtonState.Released;
            ir = new IRState();
            connected = false;
        }
        public Boolean connected;
        public Boolean isConnected()
        {
            return connected;
        }

        internal WiimoteState Copy()
        {
            WiimoteState r = (WiimoteState)this.MemberwiseClone();
            r.ir = ir.Copy();
            return r;
        }
    }
}
