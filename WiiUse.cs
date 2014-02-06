using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TheraWii
{
    class WiiUse
    {
        static IntPtr pWiimoteArray;
        static IntPtr[] pWiimote;
        static int remoteIdx;
        static int nunchuckIdx;
        static int balanceIdx;
        static bool remoteConnected;
        static bool nunchuckConnected;
        static bool balanceConnected;
        static WiimoteState remoteState;
        static NunchuckState nunchuckState;
        static BalanceBoardState balanceState;
        static bool isConnected = false;
        static int numConnected;

        const int numWiimotes = 2;
        const int timeout = 5;

        public static int Connect()
        {
            if (!isConnected)
            {
                init_structs();
                numConnected = find();
                startupPolling();
                setupPointers(numConnected);
                isConnected = true;
            }
            return numConnected;
        }

        private static void init_structs()
        {
            pWiimoteArray = WiiUseC.wiiuse_init(numWiimotes);
            pWiimote = new IntPtr[numWiimotes];
            IntPtr current = pWiimoteArray;
            for (int i = 0; i < numWiimotes; i++)
            {
                pWiimote[i] = (IntPtr)Marshal.PtrToStructure(current, typeof(IntPtr));
                current = (IntPtr)((long)current + Marshal.SizeOf(current));
            }
        }

        private static int find()
        {
            int found = WiiUseC.wiiuse_find(pWiimoteArray, numWiimotes, timeout);
            WiiUseC.wiiuse_connect(pWiimoteArray, numWiimotes);
            WiiUseC.wiiuse_set_leds(pWiimote[0], 0x10);
            WiiUseC.wiiuse_set_leds(pWiimote[1], 0x10);
            return found;
        }

        private static void startupPolling()
        {
            for (int i = 0; i < 40; i++)
            {
                Poll();
            }
        }

        private static void setupPointers(int num)
        {
            remoteConnected = false;
            nunchuckConnected = false;
            balanceConnected = false;
            remoteState = new WiimoteState();
            nunchuckState = new NunchuckState();
            balanceState = new BalanceBoardState();

            wiimote_t[] wms = MarshalWiimotes();
            for (int i = 0; i < num; i++)
            {
                if (wms[i].exp.type == WiiExpansion.EXP_NONE || wms[i].exp.type == WiiExpansion.EXP_NUNCHUK)
                {
                    remoteConnected = true;
                    remoteIdx = i;
                    remoteState.connected = true;
                }
                    
                if (wms[i].exp.type == WiiExpansion.EXP_NUNCHUK)
                {
                    nunchuckConnected = true;
                    nunchuckIdx = i;
                    nunchuckState.connected = true;
                }
                if (wms[i].exp.type == WiiExpansion.EXP_BALANCE)
                {
                    balanceConnected = true;
                    balanceIdx = i;
                    balanceState.connected = true;
                }
            }
        }

        public static void Disconnect()
        {
            if (isConnected)
            {
                remoteConnected = false;
                nunchuckConnected = false;
                balanceConnected = false;
                remoteState.connected = false;
                nunchuckState.connected = false;
                balanceState.connected = false;
                isConnected = false;

                // This calls wiiuse_disconnect as well
                WiiUseC.wiiuse_cleanup(pWiimoteArray, numWiimotes);
            }
        }

        public static bool IsConnected(WiiType type)
        {
            switch (type)
            {
                case WiiType.Remote:
                    return remoteConnected;
                case WiiType.Nunchuck:
                    return nunchuckConnected;
                case WiiType.BalanceBoard:
                    return balanceConnected;
                case WiiType.Mouse:
                    return true;
                default:
                    return false;
            }
        }

        public static wiimote_t[] MarshalWiimotes()
        {
            wiimote_t[] wms = new wiimote_t[numWiimotes];
            for (int i = 0; i < numWiimotes; i++)
            {
                wms[i] = (wiimote_t)Marshal.PtrToStructure(pWiimote[i], typeof(wiimote_t));
            }
            return wms;
        }

        public static WIIUSE_EVENT_TYPE[] Poll()
        {
            WIIUSE_EVENT_TYPE[] returnEvents = new WIIUSE_EVENT_TYPE[numWiimotes];
            for (int i = 0; i < numWiimotes; i++)
            {
                returnEvents[i] = WIIUSE_EVENT_TYPE.WIIUSE_NONE;
            }

            if (WiiUseC.wiiuse_poll(pWiimoteArray, numWiimotes) > 0)
            {
                /*
                 *	This happens if something happened on any wiimote.
                 *	So go through each one and check if anything happened.
                 */
                wiimote_t[] wms = MarshalWiimotes();
                for (int i = 0; i < numWiimotes; i++)
                {
                    returnEvents[i] = wms[i].eventw;
                    if (remoteConnected && i == remoteIdx)
                    {
                        // Create Remote state from wiimote_t struct
                        updateRemote(wms[i]);
                    }
                    if (nunchuckConnected && i == nunchuckIdx)
                    {
                        // Create Nunchuck state from wiimote_t struct
                        updateNunchuck(wms[i]);
                    }
                    if (balanceConnected && i == balanceIdx)
                    {
                        // Create Balance state from wiimote_t struct
                        updateBalance(wms[i]);
                    }
                }
            }

            return returnEvents;
        }

        private static void updateRemote(wiimote_t w)
        {
            remoteState.a = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_A) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.b = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_B) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.dDown = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_DOWN) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.dLeft = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_LEFT) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.dRight = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_RIGHT) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.dUp = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_UP) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.home = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_HOME) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.minus = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_MINUS) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.plus = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_PLUS) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.one = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_ONE) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.two = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_TWO) ? ButtonState.Pressed : ButtonState.Released;
            remoteState.roll = w.orient.roll;
            remoteState.pitch = w.orient.pitch;
            remoteState.ir.x = MathHelper.Lerp(-1, 1, MathHelper.Clamp((float)w.ir.x / w.ir.vres[0], 0.0f, 1.0f));
            remoteState.ir.y = -MathHelper.Lerp(-1, 1, MathHelper.Clamp((float)w.ir.y / w.ir.vres[1], 0.0f, 1.0f));
            remoteState.ir.distance = w.ir.z;
            remoteState.accel.X = w.gforce.x;
            remoteState.accel.Y = w.gforce.y;
            remoteState.accel.Z = w.gforce.z;
        }

        private static void updateNunchuck(wiimote_t w)
        {
            nunchuckState.c = WiiUseC.IS_PRESSED(w, WiiUseC.NUNCHUK_BUTTON_C) ? ButtonState.Pressed : ButtonState.Released;
            nunchuckState.z = WiiUseC.IS_PRESSED(w, WiiUseC.NUNCHUK_BUTTON_Z) ? ButtonState.Pressed : ButtonState.Released;
            nunchuckState.roll = w.exp.nunchuk.orient.roll;
            nunchuckState.pitch = w.exp.nunchuk.orient.pitch;
            nunchuckState.joyAngle = w.exp.nunchuk.js.ang;
            nunchuckState.joyMagnitude = w.exp.nunchuk.js.mag;
            nunchuckState.accel.X = w.gforce.x;
            nunchuckState.accel.Y = w.gforce.y;
            nunchuckState.accel.Z = w.gforce.z;

            if (float.IsNaN(nunchuckState.joyAngle))
            {
                nunchuckState.joyAngle = 0;
            }
        }

        private static void updateBalance(wiimote_t w)
        {
            balanceState.button = WiiUseC.IS_PRESSED(w, WiiUseC.WIIMOTE_BUTTON_A) ? ButtonState.Pressed : ButtonState.Released;
            balanceState.frontLeft = w.exp.balance.feet.fl;
            balanceState.frontRight = w.exp.balance.feet.fr;
            balanceState.backLeft = w.exp.balance.feet.bl;
            balanceState.backRight = w.exp.balance.feet.br;
        }

        public static WiimoteState GetRemoteState()
        {
            return remoteState.Copy();
        }

        public static NunchuckState GetNunchuckState()
        {
            return nunchuckState.Copy();
        }

        public static BalanceBoardState GetBalanceBoardState()
        {
            return balanceState.Copy();
        }

        public static void EnableMotionSensing()
        {
            WiiUseC.wiiuse_motion_sensing(pWiimote[remoteIdx], 1);
        }

        public static void DisableMotionSensing()
        {
            WiiUseC.wiiuse_motion_sensing(pWiimote[remoteIdx], 0);
        }

        public static void EnableIR()
        {
            WiiUseC.wiiuse_set_ir(pWiimote[remoteIdx], 1);
        }

        public static void DisableIR()
        {
            WiiUseC.wiiuse_set_ir(pWiimote[remoteIdx], 0);
        }
    }
}
