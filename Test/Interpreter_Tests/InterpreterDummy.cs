using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test.Interpreter_Tests
{
    public class InterpreterDummy
    {   
        public string Name { get; set; }

        public string Message { get; set; }

        public string Followee { get; set; }        

        public bool Posting { get; set; }

        public bool Reading { get; set; }

        public bool Following { get; set; }

        public bool Wall { get; set; }

        private string _Regex = string.Empty;

        public InterpreterDummy(string regex)
        {
            _Regex = regex;
        }

        public void Execute(string input)
        {
            var theReg = new Regex(_Regex);

            var theMatches = theReg.Matches(input);

            foreach (Match match in theMatches)
            {
                if(match.Length != 0)
                {
                    Reading = !string.IsNullOrEmpty(match.Groups[Constants.GR_READING].ToString());
                    Posting = !string.IsNullOrEmpty(match.Groups[Constants.GR_POSTING].ToString());
                    Following = !string.IsNullOrEmpty(match.Groups[Constants.GR_FOLLOWING].ToString());
                    Wall = !string.IsNullOrEmpty(match.Groups[Constants.GR_WALL].ToString());

                    Name = match.Groups[Constants.GR_NAME].ToString();
                    Message = match.Groups[Constants.GR_MESSAGE].ToString();
                    Followee = match.Groups[Constants.GR_FOLLOWEE].ToString();
                }
            }
        }
    }
}
