using Newtonsoft.Json;

namespace Oxide.Ext.Discord;

[Serializable]
public class EmbedField
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("inline")]
    public bool Inline { get; set; }

    public EmbedField Clone()
    {
        return new EmbedField
        {
            Name = Name,
            Value = Value,
            Inline = Inline
        };
    }
}