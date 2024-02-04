using JetBrains.Annotations;
using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Ext.Discord;

[UsedImplicitly]
public class DiscordExt : Extension
{
    private static readonly VersionNumber s_extensionVersion = new(1, 0, 0);

    public override string Name => "Discord";
    public override string Author => "Ilovepatatos";
    public override VersionNumber Version => s_extensionVersion;

    public override bool SupportsReloading => true;

    public DiscordExt(ExtensionManager manager) : base(manager) { }
}