using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;


namespace SteamAchievementHunterWeb
{
    public class IncompletePercentage
    {
        public double percentage;
        public string name;

        public IncompletePercentage(GlobalAchievementPercentageModel gap, PlayerAchievementModel pam)
        {
            percentage = gap.Percent;
            percentage = Math.Round(percentage,2);
            name = pam.Name;
        }
    }
}
