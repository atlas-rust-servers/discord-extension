using Newtonsoft.Json;

namespace Oxide.Ext.DiscordExt;

[Serializable]
public class Provider
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; }
}