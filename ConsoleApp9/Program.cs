using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIN_LIB;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
             foreach ( var s in  Countru.CountruMas())
             {
                if ( s.GetName("WA9" ) != null)
                Console.WriteLine(s);
             }

            Console.Read();
        }
    }
}
