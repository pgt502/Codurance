using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class Interpreter 
    {   
        private string _Regex = string.Empty;

        private ISocialNetwork _SocialNetwork;

        public Interpreter(string regex, ISocialNetwork socialNetwork)
        {
            _Regex = regex;
            _SocialNetwork = socialNetwork;
        }

        public List<string> Execute(string input)
        {
            List<string> output = null;

            var theReg = new Regex(_Regex);

            var theMatches = theReg.Matches(input);

            if (_SocialNetwork == null) return null;

            foreach (Match match in theMatches)
            {
                if(match.Length != 0)
                {
                    var name = match.Groups[Constants.GR_NAME].ToString();
                    var message = match.Groups[Constants.GR_MESSAGE].ToString();
                    var followee = match.Groups[Constants.GR_FOLLOWEE].ToString();

                    if(!string.IsNullOrEmpty(match.Groups[Constants.GR_READING].ToString()))
                    {
                        output = _SocialNetwork.Read(name);
                    }                    
                    if(!string.IsNullOrEmpty(match.Groups[Constants.GR_POSTING].ToString()))
                    {
                        _SocialNetwork.Post(name, message);
                        output = new List<string>();
                    }
                    if(!string.IsNullOrEmpty(match.Groups[Constants.GR_FOLLOWING].ToString()))
                    {
                        _SocialNetwork.Follow(name, followee);
                        output = new List<string>();
                    }
                    if(!string.IsNullOrEmpty(match.Groups[Constants.GR_WALL].ToString()))
                    {
                        output = _SocialNetwork.Wall(name);
                    }                    
                }
            }

            return output;
        }        
       
    }
}
