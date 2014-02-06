using System;
using System.Collections.Generic;
using System.Text;

namespace TheraWii
{
    public enum InputHandling
    {
        Absolute = 0, Differential
    }

    public class InputHandlingNames
    {
        public static string[] InputHandlingStrings = new string[] {
            "Absolute",
            "Differential"
        };
    }
}
