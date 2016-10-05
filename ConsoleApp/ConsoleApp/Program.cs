using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VbImplementations.Cti;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Programmer x = new Programmer();
            x.ClockIn();
            x.DoWork();
            x.GoHome();
            Employee y = (Employee)x;
            y.ClockIn();
           // y.DoWork();
            y.GoHome();


            B ss = new B();
            Console.WriteLine(ss.func1());

            Console.ReadLine();

        }

        abstract class A
        {
           virtual public string func1()
            {
                return "base";
            }

        }

        class B : A
        {
            override
            public string func1()
            {
                return base.func1() + " derived";
            }

        }

    }
}
