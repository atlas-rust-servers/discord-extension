using Newtonsoft.Json;

namespace Oxide.Ext.DiscordExt;

[Serializable]
public class EmbedAuthor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("icon_url")]
    public string IconUrl { get; set; }

    [JsonProperty("proxy_icon_url")]
    public string ProxyIconUrl { get; set; }

    public EmbedAuthor Clone()
    {
        return new EmbedAuthor
        {
            Name = Name,
            Url = Url,
            IconUrl = IconUrl,
            ProxyIconUrl = ProxyIconUrl
        };
    }
}