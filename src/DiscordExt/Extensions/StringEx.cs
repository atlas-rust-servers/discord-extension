using JetBrains.Annotations;

namespace Oxide.Ext.DiscordExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class StringEx
{
    public static string ParseWebhookID(this string webhook)
    {
        // https://discordapp.com/api/webhooks/target_id/target_guid

        int last = webhook.LastIndexOf("/", StringComparison.Ordinal);
        string temp = webhook.Substring(0, last);

        last = temp.LastIndexOf("/", StringComparison.Ordinal) + 1;
        return temp.Substring(last, temp.Length - last);
    }

    public static string ParseWebhookGuid(this string webhook)
    {
        // https://discordapp.com/api/webhooks/target_id/target_guid

        int last = webhook.LastIndexOf("/", StringComparison.Ordinal) + 1;
        return webhook.Substring(last, webhook.Length - last);
    }
}