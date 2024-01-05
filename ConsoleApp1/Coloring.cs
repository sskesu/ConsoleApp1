using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coloring
{
    public class ChangeColor
    {
        public static void ColorMagenta(string str)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void ColorYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void ColorBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void ColorRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
