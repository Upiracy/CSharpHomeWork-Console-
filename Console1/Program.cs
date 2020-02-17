using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class IlligalInput : Exception { };

    class Program
    {
        char[] opts = new char[4] { '+', '-', '*', '/'};

        int getLevel(char o)
        {
            for(int i = 0; i < 4; i++)
            { 
                if (o == opts[i]) return i;
            }
            return -1;
        }

        int checkStr(ref string str)
        {
            string res = "";
            bool opt = false;
            int length = str.Length;
            int m = 0;
            for(int i = 0; i < length; i++)
            {
                if (getLevel(str[i]) != -1)
                {
                    if (!opt)
                    {
                        res += str[i];
                        m = i;
                        opt = true;
                    }
                    else throw new IlligalInput();
                }
                else if (str[i] >= '0' && str[i] <= '9') res += str[i];
                else if (str[i] != ' ') throw new IlligalInput();
            }
            if (res == "") throw new IlligalInput();
            str = res;
            return m;//?
        }

        void Parse(string str, out int a, out int b, out char opt)
        {
            int opti = checkStr(ref str);
            if (opti == 0 || opti == str.Length) throw new IlligalInput();//?
            a = int.Parse(str.Substring(0, opti));
            b = int.Parse(str.Substring(opti + 1));
            opt = str[opti];
        }

        static void Main(string[] args)
        {
            for (; ; )
            {
                try {
                    Program p = new Program();
                    string str = Console.ReadLine();
                    int a, b;
                    char opt;
                    p.Parse(str, out a, out b, out opt);
                    if (opt == '+')
                        Console.WriteLine(a + b);
                    else if (opt == '-')
                        Console.WriteLine(a - b);
                    else if (opt == '*')
                        Console.WriteLine(a * b);
                    else if (opt == '/')
                        Console.WriteLine((float)a / b);
                }
                catch (IlligalInput)
                {
                    Console.WriteLine("Illigal Input!");
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                    Console.ReadLine();
                }
            }
        }
    }
}
