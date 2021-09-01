using R2API;
using System;

namespace HenryMod.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Soldier
            var prefix = HenryPlugin.developerPrefix + "_SOLDIER_BODY_";

            var desc = "Soldier is a versatile combat class.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Soldiers generally want to be shooting down at their opponents to maximize the effect of their rockets splash damage." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Because of the splash damage from the rocket jump, Soldiers have to trade health for the height advantage." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > His large health pool is second only to that of the Heavy, and his wide array of armaments and weaponry allows him to bring whatever weapon or equipment is best suited to the situation at hand." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Tough and well-armed, he is versatile, capable of both offense and defense, and a great starter class to get familiar with the game." + Environment.NewLine + Environment.NewLine;

            var outro = "..and so he left, flying further than the stars.";
            var outroFailure = "..and so he vanished, in a whisper of silence.";

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
            LanguageAPI.Add(prefix + "ROBO_SKIN_NAME", "GRY Team");
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
            LanguageAPI.Add(prefix + "PRIMARY_STOCK_DESCRIPTION", Helpers.agilePrefix + Helpers.selfDamagePrefix + $"Fire a rocket for <style=cIsDamage>700% damage</style>. Can rocket jump for 150% damage.");

            LanguageAPI.Add(prefix + "PRIMARY_FAST_NAME", "Direct Hit");
            LanguageAPI.Add(prefix + "PRIMARY_FAST_DESCRIPTION", Helpers.agilePrefix + Helpers.selfDamagePrefix + Helpers.airshotPrefix + $"Fire a fast moving rocket for <style=cIsDamage>850% damage</style> with a tight explosion radius. Can rocket jump for 350% damage..");

            LanguageAPI.Add(prefix + "PRIMARY_HEAL_NAME", "Black Box");
            LanguageAPI.Add(prefix + "PRIMARY_HEAL_DESCRIPTION", Helpers.agilePrefix + Helpers.selfDamagePrefix + $"Fire a rocket for <style=cIsDamage>650% damage</style> and heal for <style=cIsHealing>15% of the damage dealt</style>. Can rocket jump for 150% damage.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_SHOTGUN_NAME", "Shotgun");
            LanguageAPI.Add(prefix + "SECONDARY_SHOTGUN_DESCRIPTION", "Fire a blast of bullets for <style=cIsDamage>5x100% damage</style>. Critical hits have a 1m explosion radius.");

            LanguageAPI.Add(prefix + "SECONDARY_BISON_NAME", "Righteous Bison");
            LanguageAPI.Add(prefix + "SECONDARY_BISON_DESCRIPTION", "Fire a laser beam for <style=cIsDamage>350% damage</style> that penetrates enemies, and can hit the same enemy multiple times.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_BUFF_NAME", "Buff Banner");
            LanguageAPI.Add(prefix + "UTILITY_BUFF_DESCRIPTION", "Charge by dealing damage. Blow your trumpet to boost your allies’ <style=cIsDamage>damage by 75%</style> in a 20m radius.");

            LanguageAPI.Add(prefix + "UTILITY_HEAL_NAME", "Concheror");
            LanguageAPI.Add(prefix + "UTILITY_HEAL_DESCRIPTION", "Charge by dealing damage. Blow your seashell to boost your allies’ <style=cIsUtility>movement speed by 35%</style> in a 20m radius and <style=cIsHealing>provide 1% healing on hit</style>.");

            LanguageAPI.Add(prefix + "UTILITY_TANK_NAME", "Battalion's Backup");
            LanguageAPI.Add(prefix + "UTILITY_TANK_DESCRIPTION", "Charge by dealing damage. Blow your horn to boost your allies’ <style=cIsUtility>armor by 60</style> and <style=cHealth>max health by 50%</style>.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_NAME", "Market Gardener");
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_DESCRIPTION", $"Swing your shovel for <style=cIsDamage>100% damage</style>. If you are <style=cIsUtility<airborne after rocket-jumping</style>, it deals  <style=cIsDamage>1500% damage</style>.");

            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_SCEPTER_NAME", "Australium Market Gardener");
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_SCEPTER_DESCRIPTION", $"Swing your shovel for <style=cIsDamage>100% damage</style>. If you are <style=cIsUtility<airborne after rocket-jumping</style>, it deals  <style=cIsDamage>2500% damage</style>.");

            LanguageAPI.Add(prefix + "SPECIAL_PICK_NAME", "Equalizer");
            LanguageAPI.Add(prefix + "SPECIAL_PICK_DESCRIPTION", $"Swing your pickaxe for <style=cIsDamage>150% damage</style>. Deals up to <style=cIsDamage>+200% increased damage</style> based on missing health.");

            LanguageAPI.Add(prefix + "SPECIAL_PICK_SCEPTER_NAME", "Australium Equalizer");
            LanguageAPI.Add(prefix + "SPECIAL_PICK_SCEPTER_DESCRIPTION", $"[Heavy]. Swing your pickaxe for <style=cIsDamage>150% damage</style>. Deals up to <style=cIsDamage>+400% increased damage</style> and <style=cIsUtility>move up to 100% faster</style> based on missing health.");
            
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_NAME", "The Half-Zatoichi");
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_DESCRIPTION", $"Swing your sword for <style=cIsDamage>100% damage</style>. If it kills, heals for <style=cIsHealing>1% health</style>. Killing bosses restores <style=cIsHealing>25% health</style>." +
                $" <style=cDeath>Instantly kills another half-zatoichi wielder and heals for 100% health</style>.");

            LanguageAPI.Add(prefix + "SPECIAL_SWORD_SCEPTER_NAME", "Australium Half-Zatoichi");
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_SCEPTER_DESCRIPTION", $"Swing your sword for <style=cIsDamage>100% damage</style>. Heals for <style=cIsHealing>1% health</style> on hit. If it kills, heals for <style=cIsHealing>5% health</style>. Killing bosses restores <style=cIsHealing>75% health</style>." +
                $" <style=cDeath>Instantly kills another half-zatoichi wielder and heals for 100% health</style>.");
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