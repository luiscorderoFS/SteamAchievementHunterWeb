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
    public class Program
    {
        //Global Variables used to pass info the Razor Page
        //public static PlayerSummaryModel playerSummaryData;
        //public static List<OwnedGameModel> games;
        //public static List<PlayerAchievementModel> achievementList;
        //public static List<GlobalAchievementPercentageModel> percentList = new List<GlobalAchievementPercentageModel>();
        //public static List<IncompletePercentage> incompleteAchList = new List<IncompletePercentage>();
        //public static List<SchemaGameAchievementModel> imageList = new List<SchemaGameAchievementModel>();
        //public static string oneGame;
        //public static IncompletePercentage passOn;
        //public static Random randy = new Random();
        public static void Main(string[] args)
        {
            //ulong nate = 76561198018711540; //nate
            //ulong fernando = 76561198097815532; //Fernando
            //ulong juan = 76561199024005983; //Juan
            //ulong luis = 76561198054594019; //Luis; 
            //ulong mad = 76561198083577140; //Mad
            //steamUserWithID temp = new steamUserWithID(luis);
            //await temp.initAsync();
            //playerSummaryData = temp.playerSummaryData;
            //games = temp.games;
            //achievementList = temp.achievementList;
            //percentList = temp.percentList;
            //incompleteAchList = temp.incompleteAchList;
            //imageList = temp.imageList;
            //passOn = temp.randomAchievement();
            //oneGame = temp.randomOwnedGame.Name;
            #region oldCode
            //// factory to be used to generate various web interfaces
            //var webInterfaceFactory = new SteamWebInterfaceFactory("AE4AFAB67BEBF82BAF22E19DC4BB53E6");

            //// this will map to the ISteamUser endpoint that allows me to access user information such as name
            //var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());

            //// this will map to ISteamUser/GetPlayerSummaries method in the Steam Web API
            //var playerSummaryResponse = await steamInterface.GetPlayerSummaryAsync(steamId);
            //playerSummaryData = playerSummaryResponse.Data;

            //// this will map to the IPlayerService endpoint that allows me to view a user's library
            //var steamPlayerInterface = webInterfaceFactory.CreateSteamWebInterface<PlayerService>();
            //var ownedGames = await steamPlayerInterface.GetOwnedGamesAsync(steamId, includeAppInfo: true);
            //games = (List<OwnedGameModel>)ownedGames.Data.OwnedGames;
            //games.Sort((a, b) => (a.Name[0].CompareTo(b.Name[0])));
            ////Selects a random game from the games collection
            //OwnedGameModel ownedGame;
            //while (true)
            //{
            //    ownedGame = getRandomGame();
            //    if (ownedGame.HasCommunityVisibleStats == true) break;
            //}

            //oneGame = ownedGame.Name;

            //// this will map to the ISteamUserStats that allows me to have access to the list of achievements, as well as their completion status
            //var steamUserStatInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUserStats>(new HttpClient());
            //try 
            //{
            //    //this gets the achievement list of the user both achieved and not 
            //    var playerAchievementResponse = await steamUserStatInterface.GetPlayerAchievementsAsync(ownedGame.AppId, steamId);
            //    achievementList = (List<PlayerAchievementModel>)playerAchievementResponse.Data.Achievements;
            //    //this gets the achievement list and the percentage of people that completed it
            //    var globalAchievementResponse = await steamUserStatInterface.GetGlobalAchievementPercentagesForAppAsync(ownedGame.AppId);
            //    percentList = (List<GlobalAchievementPercentageModel>)globalAchievementResponse.Data;
            //    //this gets the list that contains the picture of the achievement 
            //    var schemaGameResponse = await steamUserStatInterface.GetSchemaForGameAsync(ownedGame.AppId);
            //    imageList = (List<SchemaGameAchievementModel>)schemaGameResponse.Data.AvailableGameStats.Achievements;
            //    //sorts by the name that steam uses to catergorize the achievement names
            //    achievementList.Sort((a, b) => (a.APIName.CompareTo(b.APIName)));
            //    percentList.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            //    imageList.Sort((a, b) => (a.Name.CompareTo(b.Name)));
            //    if (achievementList != null)
            //    {
            //        for (int i = 0; i < achievementList.Count; i++)
            //        {
            //            if(achievementList[i].Achieved == 0)
            //            {
            //                incompleteAchList.Add(new IncompletePercentage(percentList[i],achievementList[i],imageList[i]));
            //            }
            //        }
            //        incompleteAchList.Sort((a, b) => b.percentage.CompareTo(a.percentage));
            //    }
            //    passOn = getRandomAchievement();
            //}
            //catch(HttpRequestException e)
            //{
            //    //in a more refined version, a try catch wouldn't be needed, the list of games that don't have achievements be filtered out
            //}
            #endregion
            CreateHostBuilder(args).Build().Run();
        }




        //public static OwnedGameModel getRandomGame()
        //{
        //   return games[randy.Next(games.Count)];
        //}

        //public static IncompletePercentage getRandomAchievement()
        //{
           
        //    return incompleteAchList[randy.Next(incompleteAchList.Count)];
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
