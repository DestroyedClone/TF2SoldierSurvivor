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

            #region Soldier
            prefix = HenryPlugin.developerPrefix + "_SOLDIER_BODY_";

            desc = "Saxton Hale is a heavy hitting tank that can uses his superior biology to kill enemies (hippies).<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > (NOT IMPL) You can choose loadout depending on closely you want the game to feel like VSH: Standard and Classic." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Use superjump to quickly get to normally unreachable areas." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Perform a weighdown midair to quickly reach the ground after being airborne." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Use your rage in a tough spot to stun all enemies." + Environment.NewLine + Environment.NewLine;

            outro = "..and so he left, flying further than the stars.";
            outroFailure = "..and so he vanished, in a whimper.";

            LanguageAPI.Add(prefix + "NAME", "Soldier");
            LanguageAPI.Add(prefix + "DESCRIPTION", desc);
            LanguageAPI.Add(prefix + "SUBTITLE", "Shock & Awe");
            LanguageAPI.Add(prefix + "LORE", "insert lore");
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", outro);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            LanguageAPI.Add(prefix + "RED_SKIN_NAME", "Reliable Excavation Demolition");
            LanguageAPI.Add(prefix + "BLU_SKIN_NAME", "Builders League United");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "STAR_");
            LanguageAPI.Add(prefix + "ROBO_SKIN_NAME", "Ring of Fired");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_GUNBOATS_NAME", "Gunboats");
            LanguageAPI.Add(prefix + "PASSIVE_GUNBOATS_DESCRIPTION", "+35% resistance to explosive damage, and +75% rocket jump resistance.");

            LanguageAPI.Add(prefix + "PASSIVE_MANTREADS_NAME", "Mantreads");
            LanguageAPI.Add(prefix + "PASSIVE_MANTREADS_DESCRIPTION", "+50% push force from rocket jumps, and become able to stomp enemies based on velocity. 75% reduction in knockback from enemy damage.");

            LanguageAPI.Add(prefix + "PASSIVE_PARACHUTE_NAME", "B.A.S.E. Jumper");
            LanguageAPI.Add(prefix + "PASSIVE_PARACHUTE_DESCRIPTION", "Become able to parachute midair. 25% rocket jump resistance.");

            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_STOCK_NAME", "Rocket Launcher");
            LanguageAPI.Add(prefix + "PRIMARY_STOCK_DESCRIPTION", Helpers.agilePrefix + $"[Self-Damage]. Fire a rocket for 700% damage. Can rocket jump for 150% damage.");

            LanguageAPI.Add(prefix + "PRIMARY_FAST_NAME", "Direct Hit");
            LanguageAPI.Add(prefix + "PRIMARY_FAST_DESCRIPTION", Helpers.agilePrefix + $"[Self-Damage]. [Airshot]. Fire a fast moving rocket for 850% damage with a tight explosion radius. Can rocket jump for 350% damage..");

            LanguageAPI.Add(prefix + "PRIMARY_HEAL_NAME", "Black Box");
            LanguageAPI.Add(prefix + "PRIMARY_HEAL_DESCRIPTION", Helpers.agilePrefix + $"[Self-Damage]. Fire a rocket for 650% damage and heal for 15*level health for every target hit. Can rocket jump for 150% damage.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_SHOTGUN_NAME", "Shotgun");
            LanguageAPI.Add(prefix + "SECONDARY_SHOTGUN_DESCRIPTION", "Fire a blast of bullets for 5x100% damage. Critical hits have a 1m explosion radius.");

            LanguageAPI.Add(prefix + "SECONDARY_BISON_NAME", "Righteous Bison");
            LanguageAPI.Add(prefix + "SECONDARY_BISON_DESCRIPTION", "Fire a laser beam for 350% damage that penetrates enemies, and can hit the same enemy multiple times.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_BUFF_NAME", "Buff Banner");
            LanguageAPI.Add(prefix + "UTILITY_BUFF_DESCRIPTION", "Charge by dealing damage. Blow your trumpet to boost your allies’ damage by 135% in a 20m radius.");

            LanguageAPI.Add(prefix + "UTILITY_HEAL_NAME", "Concheror");
            LanguageAPI.Add(prefix + "UTILITY_HEAL_DESCRIPTION", "Charge by dealing damage. Blow your seashell to boost your allies’ movement speed by 135% in a 20m radius and provide 1% healing on hit.");

            LanguageAPI.Add(prefix + "UTILITY_TANK_NAME", "Battalion's Backup");
            LanguageAPI.Add(prefix + "UTILITY_TANK_DESCRIPTION", "Charge by dealing damage. Blow your horn to boost your allies’ armor by 60 and max health by 50%.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_NAME", "Market Gardener");
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_DESCRIPTION", $"Swing your shovel for 100% damage. If you are airborne after rocket-jumping, it deals 1500% damage.");

            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_UPG_NAME", "Australium Market Gardener");
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_UPG_DESCRIPTION", $"Swing your shovel for 100% damage. If you are airborne after rocket-jumping, it deals 2500% damage.");

            LanguageAPI.Add(prefix + "SPECIAL_PICK_NAME", "Equalizer");
            LanguageAPI.Add(prefix + "SPECIAL_PICK_DESCRIPTION", $"Swing your pickaxe for 150% damage. Deals up to +200% increased damage based on missing health.");

            LanguageAPI.Add(prefix + "SPECIAL_PICK_UPG_NAME", "Australium Equalizer");
            LanguageAPI.Add(prefix + "SPECIAL_PICK_UPG_DESCRIPTION", $"[Heavy]. Swing your pickaxe for 150% damage. Deals up to +300% increased damage based on missing health. Passively move up to +100% faster based on missing health.");
            
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_NAME", "The Half-Zatoichi");
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_DESCRIPTION", $"Swing your sword for 100% damage. If it kills, heals for 1% health. Killing bosses restores 50% health.");

            LanguageAPI.Add(prefix + "SPECIAL_SWORD_UPG_NAME", "Australium Half-Zatoichi");
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_UPG_DESCRIPTION", $"Swing your sword for 100% damage. Heals for 1% health on hit. If it kills, heals for 2% health. Killing bosses restores 75% health and 100% barrier.");
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Soldier: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Soldier, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Soldier: Mastery");
            #endregion

            #region Keywords

            LanguageAPI.Add(prefix + "KEYWORD_AIRSHOT", "Deals increased damage to airborne targets.");
            LanguageAPI.Add(prefix + "KEYWORD_SELFDMG", "Deals damage to self.");
            #endregion

            #endregion
        }
    }
}