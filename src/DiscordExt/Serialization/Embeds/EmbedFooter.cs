using Newtonsoft.Json;

namespace Oxide.Ext.Discord;

[Serializable]
public class EmbedFooter
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("iconUrl")]
    public string IconUrl { get; set; }

    [JsonProperty("proxyIconUrl")]
    public string ProxyIconUrl { get; set; }

    public EmbedFooter() { }

    public EmbedFooter(string textIn, string iconUrlIn = null, string proxyIconUrlIn = null)
    {
        Text = textIn;
        IconUrl = iconUrlIn;
        ProxyIconUrl = proxyIconUrlIn;
    }

    public EmbedFooter Clone()
    {
        return new EmbedFooter
        {
            Text = Text,
            IconUrl = IconUrl,
            ProxyIconUrl = ProxyIconUrl
        };
    }
}