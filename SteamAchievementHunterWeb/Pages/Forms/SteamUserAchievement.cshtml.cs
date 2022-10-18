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
        [BindProperty(SupportsGet = true)]
        public uint appID { get; set; }
        public string appURL { get; set; }
        public steamUserWithID temp;
        public void OnGet()
        {
            temp = new steamUserWithID(steamID);
            
        }

        public IActionResult ButtonClick()
        {
            return Page();
        }
        public IActionResult check(string button)
        {
            if (!string.IsNullOrEmpty(button))
            {
                TempData["ButtonValue"] = string.Format("{0} button clicked.", button);
            }
            else
            {
                TempData["ButtonValue"] = "No button click!";
            }
            return RedirectToAction("ButtonClick");
        }
    }
}
