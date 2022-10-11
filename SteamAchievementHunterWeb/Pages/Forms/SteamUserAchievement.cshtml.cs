using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SteamAchievementHunterWeb.Models;

namespace SteamAchievementHunterWeb.Pages.Forms
{
    public class SteamUserAcheivement : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public ulong steamID { get; set; }
        public steamUserWithID temp;
        public void OnGet()
        {
            temp = new steamUserWithID(steamID);
        }


        public void RerollAchievement()
        {
            temp.randomAchievement();
            Page();
        }
    }
}
