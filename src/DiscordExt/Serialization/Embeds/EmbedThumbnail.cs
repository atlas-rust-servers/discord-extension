using Newtonsoft.Json;

namespace Oxide.Ext.DiscordExt;

[Serializable]
public class EmbedThumbnail
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("proxy_url")]
    public string ProxyUrl { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    public EmbedThumbnail() { }

    public EmbedThumbnail(string urlIn)
    {
        Url = urlIn;
    }

    public EmbedThumbnail Clone()
    {
        return new EmbedThumbnail
        {
            Url = Url,
            ProxyUrl = ProxyUrl,
            Height = Height,
            Width = Width
        };
    }
}