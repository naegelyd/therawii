using System;
using System.Collections.Generic;
using System.Text;

namespace TheraWii
{
    class IRState : WiiControllerState
    {
        public float x;
        public float y;
        public float distance;
        

        public IRState()
        {            
        }

        public void Initialize()
        {
            x = 0;
            y = 0;
            distance = 0;
            connected = false;
        }

        public Boolean connected;
        public Boolean isConnected()
        {
            return connected;
        }

        internal IRState Copy()
        {
            return (IRState)this.MemberwiseClone();
        }
    }
}
