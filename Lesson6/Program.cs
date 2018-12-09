using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson6
{
    public delegate double Fun(double x, double y);
    public delegate double OneFun(double x);
    class Program
    {
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x + 30 * x + 25;
        }

        public static double F3(double x)
        {
            return 2 * x * x + 5 * x;
        }

        public static void Table(Fun F, double x, double y, double b)
        {
            Console.WriteLine("------ X ------- Y ------");
            while (x <= b)
            {
                Console.WriteLine("| {0:f3}  | {1:f3}", x, F(x,y));
                x += 1;
            }
            Console.WriteLine("-----------------------");
        }
        public static double SinFunc(double a, double x)
        {
            return Math.Sin(x) * a;
        }
        public static double MyFunc(double x, double y)
        {
            return y * x * x;
        }
        public static void SaveFunc(string fileName, OneFun F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader bw = new BinaryReader(fs);
                double min = double.MaxValue;
                double d;
                for (int i = 0; i < fs.Length / sizeof(double); i++)
                {
                    d = bw.ReadDouble();
                    if (d < min) min = d;
                }
                bw.Close();
                fs.Close();
                return min;
        }

        static void Main(string[] args)
        {
            Table(new Fun(MyFunc), 1, 3, 5);
            Console.WriteLine();
            Table(SinFunc, -1, 3, 2);
            Console.WriteLine();
            var userX = 0;
            var userY = 0;
            Console.WriteLine("Put in coordinates for your function");
            userX = int.Parse(Console.ReadLine());
            Console.WriteLine("Put in coordinates for your function");
            userY = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose which function you would like to use: 1, 2 or 3");
            var userFun = int.Parse(Console.ReadLine());
            if (userFun == 1)
            {
                SaveFunc("data.bin", new OneFun(F1), userX, userY, 1);
            } else if (userFun == 2)
            {
                SaveFunc("data.bin", new OneFun(F2), userX, userY, 1);
            } else if (userFun == 3)
            {
                SaveFunc("data.bin", new OneFun(F3), userX, userY, 1);
            } else
            {
                Console.WriteLine("Uncorrect");
            }
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
            
        }
    }
}
