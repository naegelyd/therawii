using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TheraWii
{
    public enum Button {
        LeftMouse = 0,
        RightMouse,
        A,
        B,
        Up,
        Down,
        Left,
        Right,
        Plus,
        Minus,
        Home,
        One,
        Two,
        BalanceBoardButton
    }

    [XmlInclude(typeof(ButtonEndCondition)), XmlInclude(typeof(TimeLimitEndCondition)), XmlInclude(typeof(Repeat_rEndCondition)),
	 XmlInclude(typeof(Repeat_tEndCondition)), XmlInclude(typeof(Repeat_BothEndCondition))]
    public abstract class EndCondition
    {
        public abstract bool isMet(GameTime gameTime, Region r, Vector3 pos);
        public abstract List<WiiType> getRequiredDevices();
        public bool isNewExecution;
		public EndCondition() {}
		public EndCondition(EndCondition ec) {}
		public EndCondition returnNew()
		{
			if (this.GetType() == typeof(ButtonEndCondition))
				return new ButtonEndCondition((ButtonEndCondition)this);
			else if (this.GetType() == typeof(TimeLimitEndCondition))
				return new TimeLimitEndCondition((TimeLimitEndCondition)this);
			else if (this.GetType() == typeof(Repeat_rEndCondition))
				return new Repeat_rEndCondition((Repeat_rEndCondition)this);
			else if (this.GetType() == typeof(Repeat_tEndCondition))
				return new Repeat_tEndCondition((Repeat_tEndCondition)this);
			else if (this.GetType() == typeof(Repeat_BothEndCondition))
				return new Repeat_BothEndCondition((Repeat_BothEndCondition)this);
			else
				return null;
		}
    }

    public class ButtonEndCondition : EndCondition
    {
        public static string[] ButtonText = new string[] {
            "Left Mouse Button",
            "Right Mouse Button",
            "Wii Remote A",
            "Wii Remote B",
            "Wii Remote Up",
            "Wii Remote Down",
            "Wii Remote Left",
            "Wii Remote Right",
            "Wii Remote +",
            "Wii Remote -",
            "Wii Remote Home",
            "Wii Remote 1",
            "Wii Remote 2",
            "Wii Balance Board Button"
        };

        private MouseState lastMouse;
        private WiimoteState lastRemote;
        private BalanceBoardState lastBalance;

        public Button Button;

        public ButtonEndCondition()
        {
            Button = Button.LeftMouse;
            lastMouse = new MouseState();
            lastRemote = new WiimoteState();
            lastBalance = new BalanceBoardState();
        }

		public ButtonEndCondition(ButtonEndCondition ec)
		{
			Button = ec.Button;
			lastMouse = new MouseState();
			lastRemote = new WiimoteState();
			lastBalance = new BalanceBoardState();
		}

        public override bool isMet(GameTime gameTime, Region r, Vector3 pos)
        {
            MouseState mouse = Mouse.GetState();
            WiimoteState remote = WiiUse.GetRemoteState();
            BalanceBoardState balance = WiiUse.GetBalanceBoardState();
            bool rv = false;

            switch (Button)
            {
                case Button.LeftMouse:
                    rv = mouse.LeftButton == ButtonState.Pressed
                        && lastMouse.LeftButton == ButtonState.Released;
                    break;
                case Button.RightMouse:
                    rv = mouse.RightButton == ButtonState.Pressed
                        && lastMouse.RightButton == ButtonState.Released;
                    break;
                case Button.A:
                    rv = remote.a == ButtonState.Pressed
                        && lastRemote.a == ButtonState.Released;
                    break;
                case Button.B:
                    rv = remote.b == ButtonState.Pressed
                        && lastRemote.b == ButtonState.Released;
                    break;
                case Button.Up:
                    rv = remote.dUp == ButtonState.Pressed
                        && lastRemote.dUp == ButtonState.Released;
                    break;
                case Button.Down:
                    rv = remote.dDown == ButtonState.Pressed
                        && lastRemote.dDown == ButtonState.Released;
                    break;
                case Button.Left:
                    rv = remote.dLeft == ButtonState.Pressed
                        && lastRemote.dLeft == ButtonState.Released;
                    break;
                case Button.Right:
                    rv = remote.dRight == ButtonState.Pressed
                        && lastRemote.dRight == ButtonState.Released;
                    break;
                case Button.One:
                    rv = remote.one == ButtonState.Pressed
                        && lastRemote.one == ButtonState.Released;
                    break;
                case Button.Two:
                    rv = remote.two == ButtonState.Pressed
                        && lastRemote.two == ButtonState.Released;
                    break;
                case Button.Home:
                    rv = remote.home == ButtonState.Pressed
                        && lastRemote.home == ButtonState.Released;
                    break;
                case Button.Plus:
                    rv = remote.plus == ButtonState.Pressed
                        && lastRemote.plus == ButtonState.Released;
                    break;
                case Button.Minus:
                    rv = remote.minus == ButtonState.Pressed
                        && lastRemote.minus == ButtonState.Released;
                    break;
                case Button.BalanceBoardButton:
                    rv = balance.button == ButtonState.Pressed
                        && lastBalance.button == ButtonState.Released;
                    break;
                default:
                    rv = false;
                    break;
            }
            lastMouse = mouse;
            lastRemote = remote;
            lastBalance = balance;

            return rv;
        }

        public string getButtonText()
        {
            return ButtonText[(int)Button];
        }

        public override List<WiiType> getRequiredDevices()
        {
            List<WiiType> wt = new List<WiiType>();
            if ((int)Button <= 1)
                wt.Add(WiiType.Mouse);
            else if ((int)Button <= 12)
                wt.Add(WiiType.Remote);
            else if ((int)Button == 13)
                wt.Add(WiiType.BalanceBoard);
            return wt;
        }
    }

    public enum TimeLimitType {TimeInRegion, TimeOutRegion, TotalTime}

    public class TimeLimitEndCondition : EndCondition
    {
        public TimeLimitType Type;
        public double TimeLimit;
        public bool inRegion;

        protected TimeSpan elapsedTime;        

        public TimeLimitEndCondition()
        {
            Type = TimeLimitType.TotalTime;
            TimeLimit = 5;
        }

		public TimeLimitEndCondition(TimeLimitEndCondition tle)
		{
			Type = tle.Type;
			TimeLimit = tle.TimeLimit;
		}


        public override List<WiiType> getRequiredDevices()
        {
            return new List<WiiType>();
        }

        public override bool isMet(GameTime gameTime, Region r, Vector3 pos)
        {
            // reset elapsedTime on new Execution
            if (isNewExecution)
            {
                elapsedTime = new TimeSpan();
                isNewExecution = false;
                inRegion = false;
            }
            // Update
            switch (Type)
            {
                case TimeLimitType.TimeInRegion:
                    if (r.isInRegion(pos))
                    {
                        elapsedTime += gameTime.ElapsedGameTime;
                        inRegion = true;
                    }
                    else
                    {
                        elapsedTime -= elapsedTime;
						inRegion = false;
                    }
                    break;
                case TimeLimitType.TimeOutRegion:
					if (r.isInRegion(pos))
					{
						elapsedTime -= elapsedTime;
						inRegion = true;
					}
					else
					{
						elapsedTime += gameTime.ElapsedGameTime;
						inRegion = false;
					}
                    break;
                case TimeLimitType.TotalTime:
                default:
                    elapsedTime += gameTime.ElapsedGameTime;
                    break;
            }

            // Check
            return elapsedTime.TotalSeconds >= TimeLimit;
        }
        

    }

    public class Repeat_rEndCondition : EndCondition
    {
		public int numRepeats;
		public Repeat_rEndCondition() { }
		public Repeat_rEndCondition(Repeat_rEndCondition re)
		{
			numRepeats = re.numRepeats;
		}

		public override bool isMet(GameTime gameTime, Region r, Vector3 pos)
        {
            throw new NotImplementedException();
        }
        public bool isMet(int iterRepeat)
        {
			return iterRepeat >= numRepeats;
        }
        public override List<WiiType> getRequiredDevices()
        {
            return new List<WiiType>();
        }
		public void Initialize(int numRepeats)
		{
			this.numRepeats = numRepeats;
		}
    }

	public class Repeat_tEndCondition : TimeLimitEndCondition
	{
		public Repeat_tEndCondition() { }
		public Repeat_tEndCondition(Repeat_tEndCondition ec)
		{
			this.TimeLimit = ec.TimeLimit;
			this.Type = ec.Type;
		}
		public bool isMet(GameTime gameTime)
		{
			// reset elapsedTime on new Execution
			if (isNewExecution)
			{
				elapsedTime = new TimeSpan();
				isNewExecution = false;
				inRegion = false;
			}
			elapsedTime += gameTime.ElapsedGameTime;
			// Check
			return elapsedTime.TotalSeconds >= TimeLimit;
		}
		public void Initialize(int TimeLimit)
		{
			this.TimeLimit = TimeLimit;
		}
	}

	public class Repeat_BothEndCondition: EndCondition
	{
		public Repeat_rEndCondition rEnd;
		public Repeat_tEndCondition tEnd;
		public Repeat_BothEndCondition()
		{
			rEnd = new Repeat_rEndCondition();
			tEnd = new Repeat_tEndCondition();
			tEnd.Type = TimeLimitType.TotalTime;
		}
		public Repeat_BothEndCondition(Repeat_BothEndCondition ec)
		{
			rEnd = new Repeat_rEndCondition(ec.rEnd);
			tEnd = new Repeat_tEndCondition(ec.tEnd);
			tEnd.Type = TimeLimitType.TotalTime;
		}
		public void Initialize(int NumberRepeats, int TotalTimeLimit)
		{
			rEnd.numRepeats = NumberRepeats;
			tEnd.TimeLimit = TotalTimeLimit;
		}

		public override bool isMet(GameTime gameTime, Region r, Vector3 pos)
        {
            throw new NotImplementedException();
        }

		public bool isMet(int iterRepeat, GameTime gameTime)
		{
			return rEnd.isMet(iterRepeat) && tEnd.isMet(gameTime);
		}
		public override List<WiiType> getRequiredDevices()
		{
			return new List<WiiType>();
		}
	}

}

