using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
using Steam.Models;


namespace SteamAchievementHunterWeb
{
    public class IncompletePercentage
    {
        public double percentage;
        public string name;
        public string image;

        public IncompletePercentage(GlobalAchievementPercentageModel gap, PlayerAchievementModel pam, SchemaGameAchievementModel sgam)
        {
            percentage = gap.Percent;
            percentage = Math.Round(percentage,2);
            name = pam.Name;
            image = sgam.Icon;
        }
    }
}
