using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class BlowBannerHeal : BaseBlowBanner
    {
        public override void OnEnter()
        {
            base.OnEnter();
            buffDef = Modules.Buffs.soldierBannerHeal;
        }
    }
}
