using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dak_datacrawling
{
    class Program
    {
        static void Main(string[] args)
        {
            batdongsan bd = new batdongsan();
            bd.GetData();
            Console.Read();
        }
    }
}
