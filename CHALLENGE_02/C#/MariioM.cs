using System;

namespace Challenge_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "&###@&*&###@@##@##&######@@#####@#@#@#@##@@@@@@@@@@@@@@@*&&@@@@@@@@@####@@@@@@@@@#########&#&##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@&";
            char[] inputList = input.ToCharArray();
            int result = 0;
            foreach (char symbol in inputList)
            {
                switch(symbol)
                {
                    case '#':
                        result++;break;
                    case '@':
                        result--; break;
                    case '*':
                        result *= result; break;
                    case '&':
                        Console.Write(result); break;
                    default: continue;
                }
            }
            Console.ReadLine();
        }
    }
}