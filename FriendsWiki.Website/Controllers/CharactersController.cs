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
        
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return CharacterService.GetCharacters();
        }
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string CharacterId, [FromQuery] int Rating)
        {
            CharacterService.AddRating(CharacterId, Rating);
            return Ok();
        }
    }
}
