using FriendsWiki.Website.Models;
using FriendsWiki.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriendsWiki.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        public CharactersController(JsonFileCharacterService characterService)
        {
            CharacterService = characterService;
        }

        public JsonFileCharacterService CharacterService { get;} 
        
        public IEnumerable<Character> Get()
        {
            return CharacterService.GetCharacters();
        }
    }
}
