using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public delegate double Fun(double x, double y);
    class Program
    {
        public static void Table(Fun F, double x, double y, double b)
        {
            Console.WriteLine("------ X ------- Y ------");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:00}  | {1,8:00}", x, F(x,y));
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
        
        static void Main(string[] args)
        {
            Table(new Fun(MyFunc), 1, 3, 5);
            Console.WriteLine();
            Table(SinFunc, 1, 3, 5);
            Console.ReadKey();
            
        }
    }
}
