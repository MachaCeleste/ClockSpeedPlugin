using ClockSpeedPlugin;
using HarmonyLib;

[HarmonyPatch]
public class ClockServerPatch
{
    [HarmonyPatch(typeof(ClockServer), "ConfigureServer")]
    class ConfigureServerPatch
    {
        static void Prefix()
        {
            Clock.multTiempo = Plugin.timeDiv.Value;
        }
    }
}