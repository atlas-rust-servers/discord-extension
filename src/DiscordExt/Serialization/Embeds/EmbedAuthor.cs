using Newtonsoft.Json;

namespace Oxide.Ext.Discord;

[Serializable]
public class EmbedAuthor
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("iconUrl")]
    public string IconUrl { get; set; }

    [JsonProperty("proxyIconUrl")]
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