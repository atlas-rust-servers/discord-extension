#if CARBON

using API.Assembly;
using JetBrains.Annotations;

namespace Oxide.Ext.DiscordExt;

[UsedImplicitly]
public class CarbonExtension : ICarbonExtension
{
    void ICarbonAddon.Awake(EventArgs args) { }

    void ICarbonAddon.OnLoaded(EventArgs args) { }

    void ICarbonAddon.OnUnloaded(EventArgs args) { }
}

#endif
