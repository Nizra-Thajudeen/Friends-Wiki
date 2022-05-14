using FriendsWiki.Website.Models;
using FriendsWiki.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FriendsWiki.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileCharacterService CharacterService;
        public IEnumerable<Character> Characters { get; set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileCharacterService characterService)
        {
            _logger = logger;
            CharacterService = characterService;
        }

        public void OnGet()
        {
            Characters = CharacterService.GetCharacters();
        }
    }
}