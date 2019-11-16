using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickTypeCandy;

namespace IS7024_XML_Group_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //using QuickTypecandy;
            using (var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://raw.githubusercontent.com/UC-Classes/IS7024_XML_Group_Project/master/candyfile.txt");
                var candy = Candy.FromJson(jsonString);
                ViewData["Candy"] = candy;
            }
        }
    }
}
