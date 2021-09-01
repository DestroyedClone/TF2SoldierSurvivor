using BepInEx.Configuration;
using UnityEngine;
using R2API;


namespace HenryMod.Modules
{
    public static class DamageTypes
    {
        internal static DamageAPI.ModdedDamageType zatoichiKillDamageType;

        internal static void SetupDamageTypes()
        {
            zatoichiKillDamageType = R2API.DamageAPI.ReserveDamageType();
        }
    }
}