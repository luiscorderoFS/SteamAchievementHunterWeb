using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
using SteamAchievementHunterWeb.Models;

namespace SteamAchievementHunterWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public SteamIDModel steamID { get; set; }

        public void OnGet()
        {
            //IncompletePercentage placeHolder = Program.passOn;
            //ViewData["AchName"] = placeHolder.name;
            //ViewData["AchImage"] = placeHolder.image;

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            return RedirectToPage("/Forms/SteamUserAchievement", new { steamID = steamID.userID });
        }

    }
}
