using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentProgramming
{
    internal class App
    {
        static public void Main(String[] args)
        {
            ConcurrentProgramming.Class classObj = new ConcurrentProgramming.Class();
            Console.WriteLine(classObj.printHello());
        }

    }
}
