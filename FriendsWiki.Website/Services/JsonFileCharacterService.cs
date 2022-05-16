using FriendsWiki.Website.Models;
using System.Text.Json;

namespace FriendsWiki.Website.Services
{
    public class JsonFileCharacterService
    {

        public JsonFileCharacterService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "characterData.json"); }
        }

        public IEnumerable<Character> GetCharacters()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Character[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(string characterId, int rating)
        {
            var characters = GetCharacters();
            var query = characters.First(x => x.Id == characterId);

            if(query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            } 
            else
            {
                var ratingList = query.Ratings.ToList();
                ratingList.Add(rating);
                query.Ratings = ratingList.ToArray();
            }

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Character>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    characters
                );
            }
        }
    }
}
