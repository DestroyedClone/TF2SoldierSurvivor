using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;

namespace HenryMod.Modules.SurvivorComponents
{
    public class DamageBannerComponent : BaseBannerComponent
    {
        public override void Awake()
        {
            base.Awake();
            this.buffWardPrefab = Projectiles.damageBuffWard;
        }
    }
}
