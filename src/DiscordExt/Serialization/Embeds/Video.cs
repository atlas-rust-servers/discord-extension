using Newtonsoft.Json;

namespace Oxide.Ext.DiscordExt;

[Serializable]
public class Video
{
    [JsonProperty("url")]
    public string Url { get; set; }
    
    [JsonProperty("proxy_url")]
    public string ProxyUrl { get; set; }
    
    [JsonProperty("width")]
    public int? Width { get; set; }

    [JsonProperty("height")]
    public int? Height { get; set; }
}