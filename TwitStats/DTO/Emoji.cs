using Newtonsoft.Json;
using System.Collections.Generic;

namespace TwitStats.DTO
{
    internal class Emoji
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unified")]
        public string Unified { get; set; }

        [JsonProperty("non_qualified")]
        public string Non_qualified { get; set; }

        [JsonProperty("docomo")]
        public string Docomo { get; set; }

        [JsonProperty("au")]
        public string Au { get; set; }

        [JsonProperty("softbank")]
        public string Softbank { get; set; }

        [JsonProperty("google")]
        public string Google { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("sheet_x")]
        public int Sheet_x { get; set; }

        [JsonProperty("sheet_y")]
        public int Sheet_y { get; set; }

        [JsonProperty("short_name")]
        public string Short_name { get; set; }

        [JsonProperty("short_names")]
        public string[] Short_names { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("texts")]
        public string[] Texts { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("subcategory")]
        public string Subcategory { get; set; }

        [JsonProperty("sort_order")]
        public int Sort_order { get; set; }

        [JsonProperty("added_in")]
        public string Added_in { get; set; }

        [JsonProperty("has_img_apple")]
        public bool Has_img_apple { get; set; }

        [JsonProperty("has_img_google")]
        public bool Has_img_google { get; set; }

        [JsonProperty("has_img_twitter")]
        public bool Has_img_twitter { get; set; }

        [JsonProperty("has_imag_facebook")]
        public bool Has_imag_facebook { get; set; }

        [JsonProperty("skin_variations")]
        public Dictionary<string, object> Skin_variations { get; set; }

        [JsonProperty("obsoletes")]
        public string Obsoletes { get; set; }

        [JsonProperty("obsoleted_by")]
        public string Obsoleted_by { get; set; }
    }
}
