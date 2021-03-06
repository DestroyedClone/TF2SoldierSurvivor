using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class ShootHealRocket : BaseShootRocket
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.projectilePrefab = Modules.Projectiles.healRocketPrefab;
            this.damageCoefficient = Modules.StaticValues.healRocketDamageCoefficient;
        }
    }
}
