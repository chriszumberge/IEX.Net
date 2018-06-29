using IEX.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEX.Net.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEXClient client = new IEXClient();

            Company company = client.GetCompanyAsync("AAPL").Result;

            Console.ReadKey(false);
        }
    }
}
