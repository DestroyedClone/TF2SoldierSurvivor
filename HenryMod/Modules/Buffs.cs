using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace HenryMod.Modules
{
    public static class Buffs
    {
        // armor buff gained during roll
        internal static BuffDef armorBuff;

        internal static BuffDef scaredDebuff;
        internal static BuffDef scaredBuildingDebuff;

        internal static BuffDef weighdownBuff;
        internal static BuffDef rageBuff;
        internal static BuffDef crouchingBuff;

        internal static BuffDef soldierParachuting;
        internal static BuffDef soldierBannerCrit;
        internal static BuffDef soldierBannerHeal;
        internal static BuffDef soldierBannerTank;

        internal static List<BuffDef> buffDefs = new List<BuffDef>();

        internal static void RegisterBuffs()
        {
            armorBuff = AddNewBuff("HenryArmorBuff", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);

            scaredDebuff = AddNewBuff("Scared", Resources.Load<Sprite>("textures/itemicons/texMaskIcon"), Color.yellow, false, false);
            scaredBuildingDebuff = AddNewBuff("Scared (Building)", Resources.Load<Sprite>("textures/itemicons/texMaskIcon"), Color.yellow, false, false);

            weighdownBuff = AddNewBuff("Weighdown", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.blue, false, false);
            rageBuff = AddNewBuff("Rage", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.blue, false, false);
            crouchingBuff = AddNewBuff("Crouching", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.blue, false, false);


            soldierParachuting = AddNewBuff("Parachuting", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
            soldierBannerCrit = AddNewBuff("Buff Banner", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.yellow, false, false);
            soldierBannerHeal = AddNewBuff("Concheror", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.green, false, false);
            soldierBannerTank = AddNewBuff("Battalion's Backup", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.blue, false, false);
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