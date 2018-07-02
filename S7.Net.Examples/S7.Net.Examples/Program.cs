using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace S7.Net.Examples
{
    class Program
    {
        static void Main(string[] args)
        {

            var ip = "10.10.11.38";
            var plc = new S7.Net.Plc(CpuType.S7300, ip, 0, 2);

            Console.WriteLine("Connecting " + ip);
            plc.Open();

            Console.WriteLine("Reading items");
            var tc = new ByteTest();
            plc.ReadClass(tc, 800, 0);

            plc.Close();

            // result
            Console.WriteLine("Results: ");
            var t = typeof(ByteTest);
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in propInfos)
            {
                var val = tc.GetType().GetProperty(item.Name).GetValue(tc, null);
                Console.WriteLine("{0}: {1}", item.Name, val.ToString());
            }

            // keep console open
            Console.WriteLine("Press [Enter] to exit.");
            Console.Read();
        }
    }
}
