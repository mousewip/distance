using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace calcDistance
{
    class Program
    {
        public static void Main(String[] args)
        {
            DistanceDirections dd = new DistanceDirections();
            Console.WriteLine("Khoang cach tu ha noi den tphcm = D.D");
            dd.calc();

            Console.WriteLine("Khoang cach tu ha noi den tphcm = D.Matrix");

            DistanceMatrix dm = new DistanceMatrix();
            dm.calc();
        }
       
    }
}
