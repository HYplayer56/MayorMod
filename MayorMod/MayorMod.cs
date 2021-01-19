using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace MayorMod
{
	[BepInPlugin("gg.tomozbot.mayormod", "Mayor Mod", "1.0.1")]
	public class MayorMod : BasePlugin
	{
		public override void Load()
		{
			this._harmony = new Harmony("gg.tomozbot.mayormod");
			this._harmony.PatchAll();
		}

		private Harmony _harmony;

		public static int NumMayors;
	}
}
