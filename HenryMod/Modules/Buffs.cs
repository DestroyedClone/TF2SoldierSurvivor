using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace HenryMod.Modules
{
    public static class Buffs
    {
        internal static BuffDef soldierParachuting;
        internal static BuffDef soldierBannerCrit;
        internal static BuffDef soldierBannerHeal;
        internal static BuffDef soldierBannerTank;

        internal static BuffDef bannerChargeStack;

        internal static List<BuffDef> buffDefs = new List<BuffDef>();

        internal static void RegisterBuffs()
        {
            soldierParachuting = AddNewBuff("Parachuting", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
            soldierBannerCrit = AddNewBuff("Buff Banner", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.yellow, false, false);
            soldierBannerHeal = AddNewBuff("Concheror", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.green, false, false);
            soldierBannerTank = AddNewBuff("Battalion's Backup", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.blue, false, false);
            bannerChargeStack = AddNewBuff("Banner Charge", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.black, true, false);
        }

        // simple helper method
        internal static BuffDef AddNewBuff(string buffName, Sprite buffIcon, Color buffColor, bool canStack, bool isDebuff)
        {
            BuffDef buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = buffName;
            buffDef.buffColor = buffColor;
            buffDef.canStack = canStack;
            buffDef.isDebuff = isDebuff;
            buffDef.eliteDef = null;
            buffDef.iconSprite = buffIcon;

            buffDefs.Add(buffDef);

            return buffDef;
        }
    }
}