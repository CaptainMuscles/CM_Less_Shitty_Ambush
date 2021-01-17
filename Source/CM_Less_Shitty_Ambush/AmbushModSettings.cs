using UnityEngine;

using HarmonyLib;
using RimWorld;
using Verse;

namespace CM_Less_Shitty_Ambush
{
    public class AmbushModSettings : ModSettings
    {
        private float maxEnemyFactionMultiplier = 20.0f;
        private float maxManhunterPackMultiplier = 20.0f;
        private int maxMinutesUntilExitMapPossible = 1000;

        public float enemyFactionMultiplier = 2.0f;
        public float manhunterPackMultiplier = 2.0f;
        public int minutesUntilExitMapPossible = 42;

        public bool allowExitMapBeforeWin = false;

        public bool showDebugLogMessages = false;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref enemyFactionMultiplier, "enemyFactionMultiplier", 2.0f);
            Scribe_Values.Look(ref manhunterPackMultiplier, "manhunterPackMultiplier", 2.0f);
            Scribe_Values.Look(ref minutesUntilExitMapPossible, "minutesUntilExitMapPossible", 42);
            Scribe_Values.Look(ref allowExitMapBeforeWin, "allowExitMapBeforeWin", false);
            Scribe_Values.Look(ref showDebugLogMessages, "showDebugLogMessages", false);
        }

        public void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();

            listing_Standard.Begin(inRect);

            listing_Standard.Label("CM_Less_Shitty_Ambush_SettingEnemyFactionMultiplierLabel".Translate());
            listing_Standard.Label(enemyFactionMultiplier.ToString());
            enemyFactionMultiplier = listing_Standard.Slider(enemyFactionMultiplier, 0.01f, maxEnemyFactionMultiplier);

            listing_Standard.Label("CM_Less_Shitty_Ambush_SettingManhunterPackMultiplierLabel".Translate());
            listing_Standard.Label(manhunterPackMultiplier.ToString());
            manhunterPackMultiplier = listing_Standard.Slider(manhunterPackMultiplier, 0.01f, maxManhunterPackMultiplier);

            listing_Standard.CheckboxLabeled("CM_Less_Shitty_Ambush_SettingExitMapBeforeWinLabel".Translate(), ref allowExitMapBeforeWin);

            if (allowExitMapBeforeWin)
            {
                listing_Standard.Label("CM_Less_Shitty_Ambush_SettingMapExitGridAvailableTimeLabel".Translate());
                listing_Standard.Label(minutesUntilExitMapPossible.ToString());
                minutesUntilExitMapPossible = (int)listing_Standard.Slider(minutesUntilExitMapPossible, 0, maxMinutesUntilExitMapPossible);
            }

            listing_Standard.CheckboxLabeled("CM_Less_Shitty_Ambush_SettingDebugLogMessagesLabel".Translate(), ref showDebugLogMessages);

            listing_Standard.End();
        }

        public void UpdateSettings()
        {
        }
    }
}
