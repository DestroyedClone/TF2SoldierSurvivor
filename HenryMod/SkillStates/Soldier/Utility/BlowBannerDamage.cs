using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class BlowBannerDamage : BaseBlowBanner
    {
        public override void OnEnter()
        {
            base.OnEnter();
            buffDef = Modules.Buffs.soldierBannerCrit;
        }
    }
}
