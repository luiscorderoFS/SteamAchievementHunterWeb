using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamAchievementHunterWeb.Models
{
    public class SteamIDModel
    {
        public ulong userID { get; set; }
        public steamUserWithID user { get; set; }

        public void setUpSteamIDModel()
        {
            user = new steamUserWithID(userID);
        }
    }
}
