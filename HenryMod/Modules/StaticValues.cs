using System;

namespace HenryMod.Modules
{
    internal static class StaticValues
    {
        internal static string descriptionText = "Henry is a skilled fighter who makes use of a wide arsenal of weaponry to take down his foes.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Sword is a good all-rounder while Boxing Gloves are better for laying a beatdown on more powerful foes." + Environment.NewLine + Environment.NewLine
             + "< ! > Pistol is a powerful anti air, with its low cooldown and high damage." + Environment.NewLine + Environment.NewLine
             + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine
             + "< ! > Bomb can be used to wipe crowds with ease." + Environment.NewLine + Environment.NewLine;

        internal const float selfPushForce = 100f;

        // primary
        internal const float selfDamageCoefficient = 0.05f;

        internal const float stockRocketDamageCoefficient = 2f;

        internal const float fastRocketDamageCoefficient = 3f;

        internal const float healRocketDamageCoefficient = 1.5f;
        internal const float healRocketRecoverPercentage = 0.15f;

        // secondary
        internal const uint shotgunBullets = 6U;
        internal const float shotgunDamageCoefficient = 0.8f;

        internal const float bisonDamageCoefficient = 0.8f;

        // utility
        internal const float damageBuffDamageCoefficient = 0.75f;

        internal const float healBuffRecoverCoefficient = 0.35f;
        internal const float healBuffSpeedCoefficient = 0.35f;

        internal const float tankBuffArmorBoost = 60f;

        // special
        internal const float gardenDamageCoefficient = 1f;
        internal const float gardenJumpDamageCoefficient = 1f;

        internal const float gardenScepterDamageCoefficient = 1f;
        internal const float gardenScepterJumpDamageCoefficient = 1f;


        internal const float pickDamageCoefficient = 1.5f;
        internal const float pickDamageScaleCoefficient = 3f;
        internal const float pickSpeedScaleCoefficient = 0.5f;

        internal const float pickScepterDamageCoefficient = 1.5f;
        internal const float pickScepterDamageScaleCoefficient = 3f;
        internal const float pickScepterSpeedScaleCoefficient = 1f;


        internal const float swordDamageCoefficient = 1f;
        internal const float swordHealNormal = 0.05f;
        internal const float swordHealBoss = 0.15f;
        internal const float swordHealDuo = 1f;
    }
}