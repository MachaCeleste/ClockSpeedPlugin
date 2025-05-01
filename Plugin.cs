using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace ClockSpeedPlugin;

[BepInPlugin("com.machaceleste.clockspeedplugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ConfigEntry<int> timeDiv;

    private void Awake()
    {
        timeDiv = Config.Bind("Main", "Time Divisor", 14, new ConfigDescription("Sets the speed the clock runs at, must be set before singleplayer launches, default: 14:1", new AcceptableValueRange<int>(1, 32)));

        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("com.machaceleste.clockspeedplugin");
        harmony.PatchAll();
    }
}