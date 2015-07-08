using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class TestHelper
    {
        public static Message CreateMessage(int number)
        {
            var msg1 = new Message("test" + number, DateTime.Now, "user" + number);

            return msg1;
        }
    }
}
