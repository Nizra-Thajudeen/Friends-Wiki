using System.Text.Json;
using System.Text.Json.Serialization;

namespace FriendsWiki.Website.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public bool Married { get; set; }
        public string Partner { get; set; }
        public string Cast { get; set; }
        public string Image { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Character>(this);

    }
}
