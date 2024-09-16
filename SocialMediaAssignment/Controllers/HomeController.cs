using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialMediaAssignment.Models;

namespace SocialMediaAssignment.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [Route("/")]
    public IActionResult Index()
    {
        IConfigurationSection socials = _configuration.GetSection("SocialMediaLinks");
        SocialMediaLinksOptions socialMedia = new SocialMediaLinksOptions()
        {
            Facebook = socials["Facebook"],
            Instagram = socials["Instagram"],
            Twitter = socials["Twitter"],
            Youtube = socials["Youtube"]
        };
        return View(socialMedia);
    }
}
