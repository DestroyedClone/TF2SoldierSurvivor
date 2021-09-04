using System;

namespace HenryMod.Modules
{
    internal static class StaticValues
    {
        internal const float selfPushForce = 1200f;
        internal const float airshotDamageMultiplier = 2f;

        // passive
        internal const float gunboatsRocketJumpResistance = 0.75f;

        internal const float mantreadsRocketJumpForceAdditive = 0.5f;
        internal const float mantreadsPushForceResistance = 0.75f;

        // primary
        internal const float selfDamageCoefficient = 0.1f;

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

        internal const float panDamageCoefficient = 1f;
        internal const float panCookDamageCoefficient = 1.1f;
        internal const float panScepterDamageCoefficient = 5f;
        internal const float panScepterCookDamageCoefficient = 5f;

        internal const float gardenDamageCoefficient = 1f;
        internal const float gardenJumpDamageCoefficient = 5f;

        internal const float gardenScepterDamageCoefficient = 1f;
        internal const float gardenScepterJumpDamageCoefficient = 25f;


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