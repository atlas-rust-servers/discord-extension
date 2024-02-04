using Newtonsoft.Json;

namespace Oxide.Ext.Discord
{
    [Serializable]
    public class Image
    {
        [JsonProperty("url")]
        private string Url { get; set; }

        [JsonProperty("width")]
        private int? Width { get; set; }

        [JsonProperty("height")]
        private int? Height { get; set; }

        [JsonProperty("proxyURL")]
        private string ProxyUrl { get; set; }

        public Image() { }

        public Image(string url, int? width = null, int? height = null, string proxyUrl = null)
        {
            Url = url;
            Width = width;
            Height = height;
            ProxyUrl = proxyUrl;
        }

        public Image Clone()
        {
            return new Image
            {
                Url = Url,
                Width = Width,
                Height = Height,
                ProxyUrl = ProxyUrl
            };
        }
    }
}