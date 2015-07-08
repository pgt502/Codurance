using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Constants
    {
        public const string GR_POSTING = "posting";
        public const string GR_READING = "reading";
        public const string GR_FOLLOWING = "following";
        public const string GR_WALL = "wall";
        public const string GR_NAME = "name";
        public const string GR_MESSAGE = "message";
        public const string GR_FOLLOWEE = "followee";


        public static readonly string RegPosting = string.Format(@"(?<{0}>(?<{1}>\S+)\s->\s(?<{2}>\S+[\s\S]*))", GR_POSTING, GR_NAME, GR_MESSAGE);

        public static readonly string RegReading = string.Format(@"(?<{0}>(?<{1}>\S+))", GR_READING, GR_NAME);

        public static readonly string RegFollowing = string.Format(@"(?<{0}>(?<{1}>\S+)\sfollows\s(?<{2}>\S+))", GR_FOLLOWING, GR_NAME, GR_FOLLOWEE);

        public static readonly string RegWall = string.Format(@"(?<{0}>(?<{1}>\S+)\swall)", GR_WALL, GR_NAME);

        public static readonly string RegMain = string.Format("{0}|{1}|{2}|{3}", RegPosting, RegFollowing, RegWall, RegReading);
    }
}
