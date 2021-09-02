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
            LanguageAPI.Add(prefix + "PASSIVE_GUNBOATS_DESCRIPTION", $"<style=cIsUtility>+{100 * StaticValues.gunboatsRocketJumpResistance}% rocket jump resistance</style>.");

            LanguageAPI.Add(prefix + "PASSIVE_MANTREADS_NAME", "Mantreads");
            LanguageAPI.Add(prefix + "PASSIVE_MANTREADS_DESCRIPTION", $"<style=cIsUtility>+{100 * StaticValues.mantreadsRocketJumpForceAdditive} push force from rocket jumps</style>" +
                $" and <style=cIsUtility>{100 * StaticValues.mantreadsPushForceResistance}% reduction in knockback from enemy damage</style>.");

            LanguageAPI.Add(prefix + "PASSIVE_PARACHUTE_NAME", "B.A.S.E. Jumper");
            LanguageAPI.Add(prefix + "PASSIVE_PARACHUTE_DESCRIPTION", $"Become able to parachute midair. 25% rocket jump resistance.");

            #endregion

            #region Primary
            string selfDamage = $"Can rocket jump for {StaticValues.selfDamageCoefficient * 100}% self damage.";

            LanguageAPI.Add(prefix + "PRIMARY_STOCK_NAME", "Rocket Launcher");
            LanguageAPI.Add(prefix + "PRIMARY_STOCK_DESCRIPTION", Helpers.agilePrefix + Helpers.selfDamagePrefix + 
                $"Fire a rocket for <style=cIsDamage>{100 * StaticValues.stockRocketDamageCoefficient}% damage</style>. {selfDamage}");

            LanguageAPI.Add(prefix + "PRIMARY_FAST_NAME", "Direct Hit");
            LanguageAPI.Add(prefix + "PRIMARY_FAST_DESCRIPTION", Helpers.agilePrefix + Helpers.selfDamagePrefix + Helpers.airshotPrefix + 
                $"Fire a fast moving rocket for <style=cIsDamage>{100 * StaticValues.fastRocketDamageCoefficient}% damage</style> with a tight explosion radius. {selfDamage}");

            LanguageAPI.Add(prefix + "PRIMARY_HEAL_NAME", "Black Box");
            LanguageAPI.Add(prefix + "PRIMARY_HEAL_DESCRIPTION", Helpers.agilePrefix + Helpers.selfDamagePrefix + 
                $"Fire a rocket for <style=cIsDamage>{100 * StaticValues.healRocketDamageCoefficient}% damage</style> and heal for <style=cIsHealing>{100 * StaticValues.healRocketRecoverPercentage}% of the damage dealt</style>. {selfDamage}");

            LanguageAPI.Add(prefix + "PRIMARY_NODAMAGE_NAME", "Rocket Jumper");
            LanguageAPI.Add(prefix + "PRIMARY_NODAMAGE_DESCRIPTION", Helpers.agilePrefix +
                $"Fire a rocket for <style=cIsDamage>0% damage</style>.");

            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_SHOTGUN_NAME", $"Shotgun");
            LanguageAPI.Add(prefix + "SECONDARY_SHOTGUN_DESCRIPTION", $"Fire a blast of bullets for <style=cIsDamage>{StaticValues.shotgunBullets}x{100 * StaticValues.shotgunDamageCoefficient}% damage</style>." +
                $" Critical hits have a 1m explosion radius.");

            LanguageAPI.Add(prefix + "SECONDARY_BISON_NAME", $"Righteous Bison");
            LanguageAPI.Add(prefix + "SECONDARY_BISON_DESCRIPTION", $"Fire a laser beam for <style=cIsDamage>{100 * StaticValues.bisonDamageCoefficient}% damage</style> that penetrates enemies, and can hit the same enemy multiple times.");
            #endregion

            string utilityDesc(string hornName)
            {
                return $"Charge by dealing damage. Blow your {hornName} to boost your allies'";
            }

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_BUFF_NAME", $"Buff Banner");
            LanguageAPI.Add(prefix + "UTILITY_BUFF_DESCRIPTION", $"{utilityDesc("trumpet")} <style=cIsDamage>damage by {100 * StaticValues.damageBuffDamageCoefficient}%</style> in a 20m radius.");

            LanguageAPI.Add(prefix + "UTILITY_HEAL_NAME", $"Concheror");
            LanguageAPI.Add(prefix + "UTILITY_HEAL_DESCRIPTION", $"{utilityDesc("seashell")} <style=cIsUtility>movement speed by {100 * StaticValues.healBuffSpeedCoefficient}%</style> and <style=cIsHealing>provide {100 * StaticValues.healBuffRecoverCoefficient}% healing on hit</style>.");

            LanguageAPI.Add(prefix + "UTILITY_TANK_NAME", $"Battalion's Backup");
            LanguageAPI.Add(prefix + "UTILITY_TANK_DESCRIPTION", $"{utilityDesc("horn")} <style=cIsUtility>armor by {StaticValues.tankBuffArmorBoost}</style>.");
            #endregion

            #region Special

            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_NAME", $"Market Gardener");
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_DESCRIPTION", $"Swing your shovel for <style=cIsDamage>{100 * StaticValues.gardenDamageCoefficient}% damage</style>." +
                $" If you are <style=cIsUtility>airborne after rocket-jumping</style>, it deals <style=cIsDamage>{100 * StaticValues.gardenJumpDamageCoefficient}% damage</style>.");

            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_SCEPTER_NAME", $"Australium Market Gardener");
            LanguageAPI.Add(prefix + "SPECIAL_GARDEN_SCEPTER_DESCRIPTION", $"Swing your shovel for <style=cIsDamage>{100 * StaticValues.gardenScepterDamageCoefficient}% damage</style>." +
                $" If you are <style=cIsUtility>airborne after rocket-jumping</style>, it deals <style=cIsDamage>{100 * StaticValues.gardenScepterJumpDamageCoefficient}% damage</style>.");

            LanguageAPI.Add(prefix + "SPECIAL_PICK_NAME", "Equalizer");
            LanguageAPI.Add(prefix + "SPECIAL_PICK_DESCRIPTION", $"Swing your pickaxe for <style=cIsDamage>{100 * StaticValues.pickDamageCoefficient}% damage</style>." +
                $" Deals up to <style=cIsDamage>+{100 * StaticValues.pickDamageScaleCoefficient}% increased damage</style> and <style=cIsUtility>move up to {100 * StaticValues.pickSpeedScaleCoefficient}% faster</style> based on missing health.");

            LanguageAPI.Add(prefix + "SPECIAL_PICK_SCEPTER_NAME", "Australium Equalizer");
            LanguageAPI.Add(prefix + "SPECIAL_PICK_SCEPTER_DESCRIPTION", $"[Heavy]. Swing your pickaxe for <style=cIsDamage>{100 * StaticValues.pickScepterDamageCoefficient}% damage</style>." +
                $" Deals up to <style=cIsDamage>+{100 * StaticValues.pickScepterDamageScaleCoefficient} increased damage</style> and <style=cIsUtility>move up to {100 * StaticValues.pickScepterSpeedScaleCoefficient}% faster</style> based on missing health.");

            string swordWarning = $" <style=cDeath>Instantly kills another half-zatoichi wielder and heals for {100 * StaticValues.swordHealDuo}% health</style>.";

            LanguageAPI.Add(prefix + "SPECIAL_SWORD_NAME", $"The Half-Zatoichi");
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_DESCRIPTION", $"Swing your sword for <style=cIsDamage>{100 * StaticValues.swordDamageCoefficient}% damage</style>." +
                $" If it kills, heals for <style=cIsHealing>{100 * StaticValues.swordHealNormal}% health</style>." +
                $" Killing bosses restores <style=cIsHealing>{100 * StaticValues.swordHealBoss}% health</style>." +
                swordWarning);

            LanguageAPI.Add(prefix + "SPECIAL_SWORD_SCEPTER_NAME", $"Australium Half-Zatoichi");
            LanguageAPI.Add(prefix + "SPECIAL_SWORD_SCEPTER_DESCRIPTION", $"Swing your sword for <style=cIsDamage>100% damage</style>." +
                $" Heals for <style=cIsHealing>1% health</style> on hit. If it kills, heals for <style=cIsHealing>5% health</style>." +
                $" Killing bosses restores <style=cIsHealing>75% health</style>." +
                swordWarning);
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Soldier: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Soldier, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Soldier: Mastery");
            #endregion

            #region Keywords

            LanguageAPI.Add(prefix + "KEYWORD_AIRSHOT", $"Deals +{100 * StaticValues.airshotDamageMultiplier}% damage to airborne targets.");
            LanguageAPI.Add(prefix + "KEYWORD_SELFDMG", $"Deals damage to self.");
            #endregion

            #endregion
        }
    }
}