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

namespace SteamAchievementHunterWeb
{
    public class Program
    {
        //Global Variables used to pass info the Razor Page
        public static PlayerSummaryModel playerSummaryData;
        public static List<OwnedGameModel> games;
        public static List<PlayerAchievementModel> achievementList;
        public static string oneGame;

        public static async Task Main(string[] args)
        {
            
            //ulong steamId = 76561198097815532; //Fernando
            //ulong steamId = 76561199024005983; //Juan
            ulong steamId = 76561198054594019; //Luis; 

            // factory to be used to generate various web interfaces
            var webInterfaceFactory = new SteamWebInterfaceFactory("AE4AFAB67BEBF82BAF22E19DC4BB53E6");

            // this will map to the ISteamUser endpoint that allows me to access user information such as name
            var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUser>(new HttpClient());

            // this will map to ISteamUser/GetPlayerSummaries method in the Steam Web API
            var playerSummaryResponse = await steamInterface.GetPlayerSummaryAsync(steamId);
            playerSummaryData = playerSummaryResponse.Data;

            // this will map to the IPlayerService endpoint that allows me to view a user's library
            var steamPlayerInterface = webInterfaceFactory.CreateSteamWebInterface<PlayerService>();
            var ownedGames = await steamPlayerInterface.GetOwnedGamesAsync(steamId, includeAppInfo: true);
            games = (List<OwnedGameModel>)ownedGames.Data.OwnedGames;
            games.Sort((a, b) => (a.Name[0].CompareTo(b.Name[0])));
            //Selects a random game from the games collection
            var ownedGame = getRandomGame();
            oneGame = ownedGame.Name;
            
            // this will map to the ISteamUserStats that allows me to have access to the list of achievements, as well as their completion status
            var steamUserStatInterface = webInterfaceFactory.CreateSteamWebInterface<SteamUserStats>(new HttpClient());
            try 
            {
                var playerAchievementResponse = await steamUserStatInterface.GetPlayerAchievementsAsync(ownedGame.AppId, steamId);
                achievementList = (List<PlayerAchievementModel>)playerAchievementResponse.Data.Achievements;
            }
            catch(HttpRequestException e)
            {
                //in a more refined version, a try catch wouldn't be needed, the list of games that don't have achievements be filtered out
            }
            

           





            CreateHostBuilder(args).Build().Run();
        }




        public static OwnedGameModel getRandomGame()
        {
            Random randy = new Random();
            return games[randy.Next(games.Count)];
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
