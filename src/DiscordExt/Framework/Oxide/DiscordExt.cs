#if OXIDE

using JetBrains.Annotations;
using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Ext.DiscordExt;

[UsedImplicitly]
public class DiscordExt : Extension
{
    public override string Name => "DiscordExt";
    public override string Author => "Ilovepatatos";
    public override VersionNumber Version => new(1, 0, 0);

    public override bool SupportsReloading => true;

    public DiscordExt(ExtensionManager manager) : base(manager) { }
}

#endif