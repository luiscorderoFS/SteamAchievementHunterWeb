using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamWebAPI2;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Interfaces;
using System.Net.Http;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
using Steam.Models;

namespace SteamAchievementHunterWeb
{
    public class steamUserWithID
    {
        public ulong id { get; set; }
        SteamWebInterfaceFactory webInterfaceFactory;
        SteamUser steamInterface;
        SteamUserStats steamUserStatInterface;
        Random randy = new Random();
        public OwnedGameModel randomOwnedGame { get; set; }
        public PlayerSummaryModel playerSummaryData { get; set; }
        public List<OwnedGameModel> games { get; set; }
        public List<PlayerAchievementModel> achievementList { get; private set; }
        public List<GlobalAchievementPercentageModel> percentList { get; private set; }
        public List<SchemaGameAchievementModel> imageList { get; private set; }
        public List<IncompletePercentage> incompleteAchList { get; set; }
        public steamUserWithID(ulong id)
        {
            webInterfaceFactory = new SteamWebInterfaceFactory("AE4AFAB67BEBF82BAF22E19DC4BB53E6");
            steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());
            steamUserStatInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUserStats>(new HttpClient());
            
            incompleteAchList = new List<IncompletePercentage>();
            this.id = id;
        }

        public async Task initAsync()
        {
            var tempPlayerResponse = await steamInterface.GetPlayerSummaryAsync(this.id);
            playerSummaryData = tempPlayerResponse.Data;

            var steamPlayerInterface = webInterfaceFactory.CreateSteamWebInterface<PlayerService>(new HttpClient());
            var ownedGames = await steamPlayerInterface.GetOwnedGamesAsync(this.id, includeAppInfo: true);
            games = (List<OwnedGameModel>)ownedGames.Data.OwnedGames;
            games.Sort((a, b) => (a.Name[0].CompareTo(b.Name[0])));
            removeAchievementlessGames();
            await randomGame();
        }


        public async Task randomGame()
        {
            randomOwnedGame = games[randy.Next(games.Count)];
            var playerAchievementResponse = await steamUserStatInterface.GetPlayerAchievementsAsync(randomOwnedGame.AppId, id);
            achievementList = (List<PlayerAchievementModel>)playerAchievementResponse.Data.Achievements;
            //this gets the achievement list and the percentage of people that completed it
            var globalAchievementResponse = await steamUserStatInterface.GetGlobalAchievementPercentagesForAppAsync(randomOwnedGame.AppId);
            percentList = (List<GlobalAchievementPercentageModel>)globalAchievementResponse.Data;
            //this gets the list that contains the picture of the achievement 
            var schemaGameResponse = await steamUserStatInterface.GetSchemaForGameAsync(randomOwnedGame.AppId);
            imageList = (List<SchemaGameAchievementModel>)schemaGameResponse.Data.AvailableGameStats.Achievements;
            achievementList.Sort((a, b) => (a.APIName.CompareTo(b.APIName)));
            percentList.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            imageList.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            if (achievementList != null)
            {
                for (int i = 0; i < achievementList.Count; i++)
                {
                    if (achievementList[i].Achieved == 0)
                    {
                        incompleteAchList.Add(new IncompletePercentage(percentList[i], achievementList[i], imageList[i]));
                    }
                }
                incompleteAchList.Sort((a, b) => b.percentage.CompareTo(a.percentage));
            }

        }

        public void removeAchievementlessGames()
        {
            for (int i = 0; i < games.Count; i++)
            {
                if (!games[i].HasCommunityVisibleStats) games.RemoveAt(i);
            }
        }

        public IncompletePercentage randomAchievement()
        {
            return incompleteAchList[randy.Next(incompleteAchList.Count)];
        }
       
    }
}
