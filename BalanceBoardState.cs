using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

using System.Text;

namespace TheraWii
{
    class BalanceBoardState : WiiControllerState
    {
        public ButtonState button;
        public float frontLeft;
        public float frontRight;
        public float backLeft;
        public float backRight;

        public BalanceBoardState()
        {
            
        }
        
        public void Initialize()
        {
            frontLeft = 0.0f;    //measured in kg
            frontRight = 0.0f;   //measured in kg
            backLeft = 0.0f;     //measured in kg
            backRight = 0.0f;    //measured in kg
            connected = false;
            button = ButtonState.Released;
        }

        public double getWeight()
        {
            return frontLeft + frontRight + backLeft + backRight; //measured in kg
        }

        public Boolean connected;
        public Boolean isConnected()
        {
            return connected;
        }

        internal BalanceBoardState Copy()
        {
            return (BalanceBoardState)this.MemberwiseClone();
        }
    }
}
