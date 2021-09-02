using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class ShootNoDamageRocket : BaseShootRocket
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.projectilePrefab = Modules.Projectiles.noDamageRocketPrefab;
            this.damageCoefficient = 0f;
        }
    }
}
