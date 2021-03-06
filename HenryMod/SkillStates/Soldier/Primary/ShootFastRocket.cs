using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class ShootFastRocket : BaseShootRocket
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.projectilePrefab = Modules.Projectiles.fastRocketPrefab;
            this.damageCoefficient = Modules.StaticValues.fastRocketDamageCoefficient;
        }
    }
}
