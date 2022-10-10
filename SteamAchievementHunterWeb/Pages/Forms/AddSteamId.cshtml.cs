using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SteamAchievementHunterWeb.Models;

namespace SteamAchievementHunterWeb.Pages.Forms
{
    public class AddSteamIdModel : PageModel
    {
        [BindProperty]
        public SteamIDModel steamID { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }
            return RedirectToPage("/Index", new { steamID = steamID.userID });
        }
    }
}
