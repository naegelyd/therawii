using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TheraWii
{
    public enum WiiType { BalanceBoard, Remote, Nunchuck, Mouse };
    [XmlInclude(typeof(InputBalanceBoard)), XmlInclude(typeof(InputMouse)),
     XmlInclude(typeof(InputNunchuckJoystick)), XmlInclude(typeof(InputNunchuckRollPitch)),
     XmlInclude(typeof(InputRemoteIR)), XmlInclude(typeof(InputRemoteRollPitch)),
     XmlInclude(typeof(InputRemote)), XmlInclude(typeof(InputNunchuck))
    ]
    public abstract class InputDevice
    {
        public abstract WiiType getInputEnum();
        public static string[] WiiTypeString = new string[] {"BalanceBoard", "Remote", "Nunchuck", "Mouse" };
        //public abstract void outputData();

        // In range [-1.0, 1.0]
        public abstract Vector3 getXYZ();
        public abstract void writeFields(DScsv output);
        public abstract void writeStatus(DScsv output);

        [XmlIgnore]
        public static int GAME_WIDTH;
        [XmlIgnore]
        public static int GAME_HEIGHT;
        [XmlIgnore]
        public InputHandling Handling;
        protected float x, y, z;
        protected float diffScaling = 0.01f;
        protected Vector3 xyz;
        protected const int AVG_SAMPLES = 15;
        public static float alpha;

        public virtual void Initialize(Vector3 position)
        {
            x = position.X;
            y = position.Y;
            z = position.Z;

            xyz = new Vector3(position.X, position.Y, position.Z);
            alpha = 2.0f / ((float)(AVG_SAMPLES + 1));
        }

        public virtual void Finish()
        {
        }
		public InputDevice returnNew()
		{
			if (this.GetType() == typeof(InputBalanceBoard))
			{
				return new InputBalanceBoard();
			}
			else if (this.GetType() == typeof(InputRemoteIR))
			{
				return new InputRemoteIR();
			}
			else if (this.GetType() == typeof(InputRemoteRollPitch))
			{
				return new InputRemoteRollPitch();
			}
			else if (this.GetType() == typeof(InputNunchuckJoystick))
			{
				return new InputNunchuckJoystick();
			}
			else if (this.GetType() == typeof(InputNunchuckRollPitch))
			{
				return new InputNunchuckRollPitch();
			}
			else if (this.GetType() == typeof(InputMouse))
			{
				return new InputMouse();
			}
			else if (this.GetType() == typeof(InputNunchuck))
			{
				return new InputNunchuck();
			}
			else if (this.GetType() == typeof(InputRemote))
			{
				return new InputRemote();
			}
			else
			{
				return null;
			}
		}
        protected void setDifferentialXYZ(float dx, float dy, float dz)
        {
            if (Handling == InputHandling.Absolute)
            {
                // Exponential moving average
                Vector3 newSample = new Vector3(dx, dy, dz);
                xyz = alpha * newSample + (1 - alpha) * xyz;

                x = xyz.X;
                y = xyz.Y;
                z = xyz.Z;
            }
            else
            {
                x = MathHelper.Clamp(x + dx * diffScaling, -1.0f, 1.0f);
                y = MathHelper.Clamp(y + dy * diffScaling, -1.0f, 1.0f);
                z = MathHelper.Clamp(z + dz * diffScaling, -1.0f, 1.0f);
            }
        }

        public static InputDevice[] GetUnusedInputs(InputDevice primary, List<InputDevice> additionalInputs)
        {
            List<InputDevice> unused = new List<InputDevice>();
            List<InputDevice> possible = new List<InputDevice>(Input2D.GetPossibleInputs());
            possible.AddRange(Input3D.GetPossibleInputs());
            foreach (InputDevice id in possible)
            {
                if (id.GetType() != primary.GetType())
                {
                    bool found = false;
                    foreach (InputDevice addId in additionalInputs)
                    {
                        if (id.GetType() == addId.GetType())
                        {
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        unused.Add(id);
                    }
                }
            }
            return unused.ToArray();
        }
    }

    public abstract class Input2D : InputDevice
    {
        public static Input2D[] GetPossibleInputs()
        {
            return new Input2D[] {
                new InputBalanceBoard(),
                new InputRemoteIR(),
                new InputRemoteRollPitch(),
                new InputNunchuckJoystick(),
                new InputNunchuckRollPitch(),
                new InputMouse()
            };
        }

        public static int GetInputIndex(InputDevice i)
        {
            if (i.GetType() == typeof(InputBalanceBoard))
            {
                return 0;
            }
            else if (i.GetType() == typeof(InputRemoteIR))
            {
                return 1;
            }
            else if (i.GetType() == typeof(InputRemoteRollPitch))
            {
                return 2;
            }
            else if (i.GetType() == typeof(InputNunchuckJoystick))
            {
                return 3;
            }
            else if (i.GetType() == typeof(InputNunchuckRollPitch))
            {
                return 4;
            }
            else if (i.GetType() == typeof(InputMouse))
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
       

    }

    public abstract class Input3D : InputDevice
    {

        public static Input3D[] GetPossibleInputs()
        {
            return new Input3D[] {
                new InputRemote(),
                new InputNunchuck()
            };
        }

        public static int GetInputIndex(InputDevice i)
        {
            if (i.GetType() == typeof(InputRemote))
            {
                return 0;
            }
            else if (i.GetType() == typeof(InputNunchuck))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


    public class InputMouse : Input2D
    {
               
        
        public override string ToString()
        {
            return "Mouse";
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
        }

        public override Vector3 getXYZ()
        {
            float dx =  MathHelper.Lerp(-1.0f, 1.0f,
                        MathHelper.Clamp((float)Mouse.GetState().X / GAME_WIDTH, 0.0f, 1.0f));
            float dy = -MathHelper.Lerp(-1.0f, 1.0f,
                        MathHelper.Clamp((float)Mouse.GetState().Y / GAME_HEIGHT, 0.0f, 1.0f));

            setDifferentialXYZ(dx, dy, 0.0f);
            return new Vector3(x, y, z);
        }
        
        public override WiiType getInputEnum() { return WiiType.Mouse; }

        public override void writeStatus(DScsv output)
        {
            output.setData("MousePosX", getXYZ().X.ToString());
            output.setData("MousePosY", getXYZ().Y.ToString());
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                output.setData("MouseLeft", "Pressed");
            else
                output.setData("MouseLeft", "Released");
            
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                output.setData("MouseRight", "Pressed");
            else
                output.setData("MouseRight", "Released");
        }

        public override void writeFields(DScsv output)
        {
			output.addField("MousePosX");
            output.addField("MousePosY");
            output.addField("MouseLeft");
            output.addField("MouseRight");
        }
    }

    public class InputBalanceBoard : Input2D
    {
        public override string ToString()
        {
            return "Balance Board";
        }

        public override Vector3 getXYZ()
        {
            BalanceBoardState b = WiiUse.GetBalanceBoardState();
            float sum = b.frontLeft + b.frontRight + b.backLeft + b.backRight;
            float left = b.frontLeft + b.backLeft;
            float back = b.backLeft + b.backRight;
            float dx = -MathHelper.Lerp(-1.0f, 1.0f, left / sum);
            float dy = -MathHelper.Lerp(-1.0f, 1.0f, back / sum);

            setDifferentialXYZ(dx, dy, 0.0f);
            return new Vector3(x, y, z);
        }

        public override WiiType getInputEnum() { return WiiType.BalanceBoard; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            BalanceBoardState w = WiiUse.GetBalanceBoardState();
            output.setData("BalanceX", pos.X.ToString());
            output.setData("BalanceY", pos.Y.ToString());
            output.setData("BalanceFrontLeftKGS", w.frontLeft.ToString());
            output.setData("BalanceFrontRightKGS", w.frontRight.ToString());
            output.setData("BalanceBackLeftKGS", w.backLeft.ToString());
            output.setData("BalanceBackRightKGS", w.backRight.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("BalanceX");
            output.addField("BalanceY");
            output.addField("BalanceFrontLeftKGS");
            output.addField("BalanceFrontRightKGS");
            output.addField("BalanceBackLeftKGS");
            output.addField("BalanceBackRightKGS");
        }

    }

    public class InputRemoteIR : Input2D
    {
        public override string ToString()
        {
            return "Remote Pointing";
        }

        public override Vector3 getXYZ()
        {
            WiimoteState w = WiiUse.GetRemoteState();
            float dx = w.ir.x;
            float dy = w.ir.y;
            setDifferentialXYZ(dx, dy, 0.0f);
            return new Vector3(x, y, z);
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            WiiUse.EnableIR();
        }

        public override void Finish()
        {
            WiiUse.DisableIR();
            base.Finish();
        }

        public override WiiType getInputEnum() { return WiiType.Remote; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            output.setData("RemotePointerX", pos.X.ToString());
            output.setData("RemotePointerY", pos.Y.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("RemotePointerX");
            output.addField("RemotePointerY");
        }
    }

    public class InputRemoteRollPitch : Input2D
    {
        public override string ToString()
        {
            return "Remote Roll/Pitch";
        }

        public override Vector3 getXYZ()
        {
            WiimoteState w = WiiUse.GetRemoteState();
            float dx = -MathHelper.Lerp(-1.0f, 1.0f,
                        MathHelper.Clamp((2 * w.pitch + 180) / 360, 0.0f, 1.0f));
            float dy = MathHelper.Lerp(-1.0f, 1.0f,
                        MathHelper.Clamp((2 * w.roll + 180) / 360, 0.0f, 1.0f));

            setDifferentialXYZ(dx, dy, 0.0f);
            return new Vector3(x, y, z);
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            WiiUse.EnableMotionSensing();
        }

        public override void Finish()
        {
            WiiUse.DisableMotionSensing();
            base.Finish();
        }

        public override WiiType getInputEnum() { return WiiType.Remote; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            WiimoteState w = WiiUse.GetRemoteState();
            output.setData("RemoteX", pos.X.ToString());
            output.setData("RemoteY", pos.Y.ToString());
            output.setData("RemotePitch", w.pitch.ToString());
            output.setData("RemoteRoll", w.roll.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("RemoteX");
            output.addField("RemoteY");
            output.addField("RemotePitch");
            output.addField("RemoteRoll");
        }
    }
    public class InputNunchuckJoystick : Input2D
    {
        public override string ToString()
        {
            return "Nunchuck Joystick";
        }

        public override Vector3 getXYZ()
        {
            NunchuckState w = WiiUse.GetNunchuckState();
            float dx = MathHelper.Clamp(
                (float)Math.Sqrt(2) * w.joyMagnitude * (float)Math.Sin(MathHelper.ToRadians(w.joyAngle)),
                -1.0f, 1.0f);
            float dy = MathHelper.Clamp(
                (float)Math.Sqrt(2) * w.joyMagnitude * (float)Math.Cos(MathHelper.ToRadians(w.joyAngle)),
                -1.0f, 1.0f);

            setDifferentialXYZ(dx, dy, 0.0f);
            return new Vector3(x, y, z);
        }
        public override WiiType getInputEnum() { return WiiType.Nunchuck; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            NunchuckState w = WiiUse.GetNunchuckState();
            output.setData("JoystickX", pos.X.ToString());
            output.setData("JoystickY", pos.Y.ToString());
            output.setData("JoystickAngle", w.joyAngle.ToString());
            output.setData("JoystickMagnitude", w.joyMagnitude.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("JoystickX");
            output.addField("JoystickY");
            output.addField("JoystickAngle");
            output.addField("JoystickMagnitude");
        }
    }

    public class InputNunchuckRollPitch : Input2D
    {
        public override string ToString()
        {
            return "Nunchuck Roll/Pitch";
        }

        public override Vector3 getXYZ()
        {
            NunchuckState w = WiiUse.GetNunchuckState();
            float dx = MathHelper.Lerp(-1.0f, 1.0f,
                        MathHelper.Clamp((2 * w.roll + 180) / 360, 0.0f, 1.0f));
            float dy = MathHelper.Lerp(-1.0f, 1.0f,
                        MathHelper.Clamp((2 * w.pitch + 180) / 360, 0.0f, 1.0f));

            setDifferentialXYZ(dx, dy, 0.0f);
            return new Vector3(x, y, z);
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            WiiUse.EnableMotionSensing();
        }

        public override void Finish()
        {
            WiiUse.DisableMotionSensing();
            base.Finish();
        }

        public override WiiType getInputEnum() { return WiiType.Nunchuck; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            NunchuckState w = WiiUse.GetNunchuckState();
            output.setData("NunchuckX", pos.X.ToString());
            output.setData("NunchuckY", pos.Y.ToString());
            output.setData("NunchuckPitch", w.pitch.ToString());
            output.setData("NunchuckRoll", w.roll.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("NunchuckX");
            output.addField("NunchuckY");
            output.addField("NunchuckPitch");
            output.addField("NunchuckRoll");
        }
    }

    public class InputRemote : Input3D
    {
        public override string ToString()
        {
            return "Remote Acceleration";
        }

        public override Vector3 getXYZ()
        {
            WiimoteState w = WiiUse.GetRemoteState();
            setDifferentialXYZ(w.accel.X, w.accel.Y, w.accel.Z);
            return new Vector3(x, y, z);
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            WiiUse.EnableMotionSensing();
        }

        public override void Finish()
        {
            WiiUse.DisableMotionSensing();
            base.Finish();
        }

        public override WiiType getInputEnum() { return WiiType.Remote; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            output.setData("RemoteAccelX", pos.X.ToString());
            output.setData("RemoteAccelY", pos.Y.ToString());
            output.setData("RemoteAccelZ", pos.Z.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("RemoteAccelX");
            output.addField("RemoteAccelY");
            output.addField("RemoteAccelZ");
        }
    }
    public class InputNunchuck : Input3D
    {
        public override string ToString()
        {
            return "Nunchuck Acceleration";
        }

        public override Vector3 getXYZ()
        {
            NunchuckState w = WiiUse.GetNunchuckState();
            setDifferentialXYZ(w.accel.X, w.accel.Y, w.accel.Z);
            return new Vector3(x, y, z);
        }

        public override void Initialize(Vector3 position)
        {
            base.Initialize(position);
            WiiUse.EnableMotionSensing();
        }

        public override void Finish()
        {
            WiiUse.DisableMotionSensing();
            base.Finish();
        }

        public override WiiType getInputEnum() { return WiiType.Nunchuck; }

        public override void writeStatus(DScsv output)
        {
            Vector3 pos = getXYZ();
            output.setData("NunchuckAccelX", pos.X.ToString());
            output.setData("NunchuckAccelY", pos.Y.ToString());
            output.setData("NunchuckAccelZ", pos.Z.ToString());
        }

        public override void writeFields(DScsv output)
        {
            output.addField("NunchuckAccelX");
            output.addField("NunchuckAccelY");
            output.addField("NunchuckAccelZ");
        }
    }
}
