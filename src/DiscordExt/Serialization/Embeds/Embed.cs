using Newtonsoft.Json;

namespace Oxide.Ext.DiscordExt;

[Serializable]
public class Embed
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("image")]
    public Image Image { get; set; } = new();

    [JsonProperty("color")]
    public uint Color;

    [JsonProperty("timestamp")]
    public DateTimeOffset? Timestamp { get; set; }

    [JsonProperty("author")]
    public EmbedAuthor Author { get; set; } = new();

    [JsonProperty("footer")]
    public EmbedFooter Footer { get; set; } = new();

    [JsonProperty("thumbnail")]
    public EmbedThumbnail Thumbnail { get; set; } = new();

    [JsonProperty("fields")]
    public List<EmbedField> Fields { get; set; } = new();

    public Embed Clone()
    {
        var embed = new Embed
        {
            Title = Title,
            Description = Description,
            Url = Url,
            Image = Image.Clone(),
            Color = Color,
            Timestamp = Timestamp,
            Author = Author.Clone(),
            Footer = Footer.Clone(),
            Thumbnail = Thumbnail.Clone()
        };

        foreach (EmbedField field in Fields)
            embed.Fields.Add(field.Clone());

        return embed;
    }
}