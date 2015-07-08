using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sn = new SocialNetwork();
            var interpreter = new Interpreter(Constants.RegMain, sn);

            while(input != "exit")
            {
                var output = interpreter.Execute(input);
                if(output != null && output.Count > 0)
                {
                    foreach (var item in output)
                    {
                        Console.WriteLine(item);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
