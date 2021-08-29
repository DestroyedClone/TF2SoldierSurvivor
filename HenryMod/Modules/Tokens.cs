using R2API;
using System;

namespace HenryMod.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Saxton Hale
            string prefix = HenryPlugin.developerPrefix + "_SAXTONHALE_BODY_";

            string desc = "Saxton Hale is a heavy hitting tank that can uses his superior biology to kill enemies (hippies).<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > (NOT IMPL) You can choose loadout depending on closely you want the game to feel like VSH: Standard and Classic." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Use superjump to quickly get to normally unreachable areas." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Perform a weighdown midair to quickly reach the ground after being airborne." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Use your rage in a tough spot to stun all enemies." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, ready to take back Mann Co.";
            string outroFailure = "..and so he vanished, all lost to gray.";

            LanguageAPI.Add(prefix + "SAXTONHALE_NAME", "Saxton Hale");
            LanguageAPI.Add(prefix + "SAXTONHALE_DESCRIPTION", desc);
            LanguageAPI.Add(prefix + "SAXTONHALE_SUBTITLE", "President & CEO of Mann. Co");
            LanguageAPI.Add(prefix + "SAXTONHALE_LORE", "SAXTON HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAALE");
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", outro);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(prefix + "ROBOT_SKIN_NAME", "Robo-Hale");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Mann Co.");
            LanguageAPI.Add(prefix + "NUDE_SKIN_NAME", "Ring of Fired");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Classic Passive");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");

            LanguageAPI.Add(prefix + "SAXTONHALE_PASSIVE_CLASSIC_NAME", "Classic Passive");
            LanguageAPI.Add(prefix + "SAXTONHALE_PASSIVE_CLASSIC_DESCRIPTION", "Saxton Hale receives 60% reduced knockback from all attacks. Hale instantly kill enemies he lands on if traveling fast enough. Hale has fall damage immunity.");

            LanguageAPI.Add(prefix + "SAXTONHALE_PASSIVE_AUSTRALIUM_NAME", "Australium Empowered");
            LanguageAPI.Add(prefix + "SAXTONHALE_PASSIVE_AUSTRALIUM_DESCRIPTION", "Saxton Hale receives 60% reduced knockback from all attacks. Hale deals 500% damage to enemies he lands on if traveling fast enough. Hale has fall damage immunity.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_FISTS_NAME", "<color=#CF6A32>Hale's Own Fists</color>");
            LanguageAPI.Add(prefix + "PRIMARY_FISTS_DESCRIPTION", Helpers.agilePrefix + $"Swing forward for <style=cIsDamage>{100f * Config.Fists_Damage.Value}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_SUPERJUMP_NAME", "Brave Jump");
            LanguageAPI.Add(prefix + "SECONDARY_SUPERJUMP_DESCRIPTION", Helpers.agilePrefix + $"Hold down to charge your jump, and let go to <style=cIsUtility>launch yourself</style>. You are temporarily immune to knockback at the start.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_CROUCH_NAME", "Crouch");
            LanguageAPI.Add(prefix + "UTILITY_CROUCH_DESCRIPTION", "<style=cIsUtility>Crouch</style> on the ground for <style=cIsUtility>knockback immunity.</style>");

            LanguageAPI.Add(prefix + "UTILITY_WEIGHDOWN_NAME", "Weighdown");
            LanguageAPI.Add(prefix + "UTILITY_WEIGHDOWN_DESCRIPTION", "Activate to quickly <style=cIsUtility>plummet</style> towards the ground.");

            LanguageAPI.Add(prefix + "UTILITY_LUNGE_NAME", "Brave Lunge");
            LanguageAPI.Add(prefix + "UTILITY_LUNGE_DESCRIPTION", "Saxton lunges forward for 250% damage, stunning and knocking enemies back. Deals +50% increased damage to buildings.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_CLASSIC_NAME", "Classic Rage");
            LanguageAPI.Add(prefix + "SPECIAL_CLASSIC_DESCRIPTION", $"<style=cIsUtility>Scares</style> all enemies for 8 seconds.");

            LanguageAPI.Add(prefix + "SPECIAL_BRAWL_NAME", "Brawl Rage");
            LanguageAPI.Add(prefix + "SPECIAL_BRAWL_DESCRIPTION", $"+75% attack speed, -50% damage, and attacks have a 75% chance to ignite enemies for 8 seconds.");
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Saxton Hale: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Saxton Hale, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Saxton Hale: Mastery");
            #endregion

            #region Keywords

            LanguageAPI.Add(prefix + "KEYWORD_SCARED", "Slows movement speed and prevents attacking for a duration.");

            LanguageAPI.Add(prefix + "NOATTACK_SCARED_NAME", "SCARED!");
            LanguageAPI.Add(prefix + "NOATTACK_SCARED_DESCRIPTION", "You're too scared to attack!");
            #endregion

            #endregion
        }
    }
}